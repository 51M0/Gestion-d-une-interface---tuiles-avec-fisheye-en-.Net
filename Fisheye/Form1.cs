using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fisheye
{
    public delegate void SourisEventHandler(object sender, MyMouseEventArgs e);

    public partial class Fisheye : Form
    {
        int ID = 0;
        Dictionary<int, Tuile> tuiles = new Dictionary<int, Tuile>();
        Dictionary<Button, int> boutons = new Dictionary<Button, int>();

        bool isDragged = false;
        Point ptOffset;
        Point posDepart;

        public event SourisEventHandler SourisHandler;
        public MyMouseEventArgs myMouseArgs { get; set; }

        public Fisheye()
        {
            InitializeComponent();

            boutons.Add(bouton, ID);
            ID++;

            myMouseArgs = new MyMouseEventArgs();

            this.MouseMove  += new MouseEventHandler(_MouseMove);
            this.MouseDown  += new MouseEventHandler(_MouseDown);
            this.MouseUp    += new MouseEventHandler(_MouseUp);
            SourisHandler   += new SourisEventHandler(_SourisEvent);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dragEnterBouton(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // Fonction chargée chargé de modifier les paramètres d'une tuile passée avec son ID
        public void modifierTuile(Button newTuile, int IDTuile)
        {
            Button b = new Button();

            foreach (var item in boutons)
            {
                if (item.Value == IDTuile)
                {
                    b = item.Key;
                    break;
                }
            }

            b.BackColor    = newTuile.BackColor;
            b.Name         = newTuile.Name;
            b.Size         = new System.Drawing.Size(newTuile.Width, newTuile.Height);
            b.Text         = newTuile.Text;

            Tuile t = tuiles[IDTuile];

            t.couleur = newTuile.BackColor;
            t.nom = newTuile.Name;
            t.size = new System.Drawing.Size(newTuile.Width, newTuile.Height);
        }

        // Fonction chargée de supprimer une tuile passée avec son ID
        public void supprimerTuile(Button newTuile, int IDTuile)
        {
            Button b = new Button();

            foreach (var item in boutons)
            {
                if (item.Value == IDTuile)
                {
                    b = item.Key;
                    break;
                }
            }

            boutons.Remove(b);
            tuiles.Remove(IDTuile);
            b.Dispose();
        }

        // Evenement qui se déclenche lorsqu'on clique sur la tuile pour la déplacer
        private void mouseDownBouton(object sender, MouseEventArgs e)
        {
            Button tuile = (Button)sender;

            if (e.Button == MouseButtons.Right)
            {
                ModifierTuile fenetre = new ModifierTuile(this, boutons[tuile] , tuile.Text, (int)tuile.Width / 50, (int)tuile.Height / 50, tuile.BackColor);
                fenetre.Show();
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // On sauvegarde la position de départ de la tuile qu'on va déplacer
                    posDepart = new Point(tuile.Location.X, tuile.Location.Y);

                    isDragged = true;
                    Point ptStartPosition = tuile.PointToScreen(new Point(e.X, e.Y));

                    ptOffset    = new Point();
                    ptOffset.X  = tuile.Location.X - ptStartPosition.X;
                    ptOffset.Y  = tuile.Location.Y - ptStartPosition.Y;
                }
                else
                {
                    isDragged = false;
                }
            }
        }

        // Evemenement qui se déclenche lorsqu'on souhaite déplacer une tuile
        private void mouseMoveBouton(object sender, MouseEventArgs e)
        {
            Button tuile = (Button)sender;

            if (isDragged)
            {
                Point newPoint = tuile.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                tuile.Location = newPoint;
            }
        }

        // Evenement qui se déclenche lorsque l'on relache le clic droit de la souris
        //  lors du positionnement de la tuile
        private void mouseUpBouton(object sender, MouseEventArgs e)
        {
            Button tuile = (Button) sender;
            isDragged = false;

            Rectangle r = new Rectangle(tuile.Location, tuile.Size);
            bool annuler = false;


            // Placement organisé des Tuiles
            if (tuile.Location.X % 50 > 0)
            {
                if (tuile.Location.X % 50 < 50 / 2)
                    tuile.Location = new Point(tuile.Location.X - (tuile.Location.X % 50), tuile.Location.Y);
                else
                    tuile.Location = new Point(tuile.Location.X - (tuile.Location.X % 50) + 50, tuile.Location.Y);
            }

            if (tuile.Location.Y % 50 > 0)
            {
                if (tuile.Location.Y % 50 < 50 / 2)
                    tuile.Location = new Point(tuile.Location.X, tuile.Location.Y - (tuile.Location.Y % 50));
                else
                    tuile.Location = new Point(tuile.Location.X, tuile.Location.Y - (tuile.Location.Y % 50) + 50);
            }

            // Les Bords
            if (tuile.Location.X < 0)
                tuile.Location = new Point(0, tuile.Location.Y);
            if (tuile.Location.Y < 0)
                tuile.Location = new Point(tuile.Location.X, 0);

            if (tuile.Location.X + tuile.Width > panel1.Width)
                tuile.Location = new Point(panel1.Width - tuile.Width, tuile.Location.Y);

            if (tuile.Location.Y + tuile.Height > panel1.Height)
                tuile.Location = new Point(tuile.Location.X, panel1.Height - tuile.Height);


            r = new Rectangle(tuile.Location, tuile.Size);

            foreach (var item in boutons)
            {
                // On vérifie que ce n'est pas le même bouton (sinon y aura toujours une intersection avec lui même)
                if (tuile != item.Key)
                {
                    Rectangle r1 = new Rectangle(item.Key.Location, item.Key.Size);

                    Rectangle r2 = Rectangle.Intersect(r, r1);

                    if (r2.Width != 0 && r2.Height != 0)
                    {
                        annuler = true;
                        break;
                    }
                }
            }

            // Soit on annule les changements, soit on met à jour le bouton et la tuile
            if (annuler == true)
                tuile.Location = posDepart;
            else
                majLocation(tuile);
        }

        // Fonction qui met à jour la position d'une Tuile donnée
        public void majLocation(Button bouton)
        {
            int id = boutons[bouton];

            foreach (var item in tuiles)
            {
                if (item.Key == id)
                {
                    item.Value.position = bouton.Location;
                    break;
                }
            }
        }

        // Evenement chargé d'ajouter une nouvelle Tuile
        private void boutonAjouter_Click(object sender, EventArgs e)
        {
            Button tuile = new Button();

            // Si on a bien saisi les informations concernant la tuile, alors on la créé
            if (zoneNom.Text.Trim() != "" && (int)zoneLargeur.Value != 0 && (int)zoneHauteur.Value != 0)
            {
                tuile.AllowDrop = true;
                tuile.BackColor = button1.BackColor;
                tuile.Location = new System.Drawing.Point(0, 0);
                tuile.Name = zoneNom.Text;
                tuile.Size = new System.Drawing.Size((int)(50 * zoneLargeur.Value), (int)(50 * zoneHauteur.Value));
                tuile.TabIndex = 13;
                tuile.Text = zoneNom.Text;
                this.Controls.Add(tuile);
                panel1.Controls.Add(tuile);

                tuile.MouseDown += mouseDownBouton;
                tuile.MouseMove += mouseMoveBouton;
                tuile.MouseUp   += mouseUpBouton;

                boutons.Add(tuile, ID);
                tuiles.Add(ID, creerTuile(tuile));
                ID++;
            }
        }

        // Fonction chargée de créer une nouvelle "Tuile" à partir d'un "Button"
        private Tuile creerTuile(Button bouton)
        {
            Tuile tuile;

            String nom          = bouton.Text;
            Color couleur       = bouton.BackColor;
            Size dimension      = bouton.Size;
            Point position      = bouton.Location;

            tuile = new Tuile(ID, nom, couleur, position, dimension);

            return tuile;
        }

        // Evenement chargé le choisir la couleur de la tuile
        private void boutonCouleur_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        // Evenement responsable de la sauvegarde des fichiers XML (à partir de la grille actuelle)
        private void boutonSauvergarder_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Fichier XML (.xml)|*.xml";

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Grille grille = new Grille();
                grille.tuiles = new List<Tuile>(tuiles.Values);

                grille.sauvegarderGrille(saveFileDialog1.FileName);
            }
        }

        // Evenement responsable du chargement des fichiers XML
        private void boutonCharger_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Fichier XML (.xml)|*.xml|All Files (*.*)|*.*";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Grille grille = new Grille();

                grille.chargerTuiles(openFileDialog1.FileName);

                dessinerGrille(grille);
            }
        }

        // Fonction qui dessine une grille passée en paramètre
        private void dessinerGrille(Grille grille)
        {
            libererInterface();

            for (int i = 0 ; i < grille.tuiles.Count ; i++)
            {
                Tuile tuile = grille.tuiles[i];

                creerBouton(tuile);
            }
        }

        // Transforme à partir d'une "Tuile" un "Button" et l'ajoute à la liste de boutons
        private void creerBouton(Tuile tuile)
        {
            Button bouton = new Button();

            // Si on a bien saisi les informations concernant la tuile, alors on la créé
            bouton.AllowDrop = true;
            bouton.BackColor = tuile.couleur;
            bouton.Location = tuile.position;
            bouton.Name = tuile.nom;
            bouton.Size = tuile.size; 
            bouton.TabIndex = 13;
            bouton.Text = tuile.nom;
            this.Controls.Add(bouton);
            panel1.Controls.Add(bouton);

            bouton.MouseDown += mouseDownBouton;
            bouton.MouseMove += mouseMoveBouton;
            bouton.MouseUp   += mouseUpBouton;


            boutons.Add(bouton, ID);
            tuiles.Add(ID, creerTuile(bouton));
            ID++;
        }

        // Libère l'interface (Interface blanche + plus de boutons et de tuiles)
        private void libererInterface()
        {
            foreach (var item in boutons)
            {
                item.Key.Dispose();
            }

            boutons.Clear();
            tuiles.Clear();

            ID = 0;
        }

        private void _SourisEvent(object sender, MyMouseEventArgs e)
        {
            Console.WriteLine("MyMouseEvent :  clicDroit = " + myMouseArgs.clicDroit.ToString() + "          clicGauche = " + myMouseArgs.clicGauche.ToString() + "          mouvementValide = " + myMouseArgs.mouvementValide().ToString());
            if (e.mouvementValide())
            {
                //Lancer interface test
                Form2 fenetreTest = new Form2(boutons.Keys.ToList(), tuiles.Values.ToList());
                fenetreTest.Show();
                this.Invalidate();
            }
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    myMouseArgs.clicGauche = false;
                    break;
                case MouseButtons.Right:
                    myMouseArgs.clicDroit = false;
                    break;
                default:
                    break;
            }

            SourisHandler(this, myMouseArgs);
        }

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    myMouseArgs.clicGauche = true;
                    break;
                case MouseButtons.Right:
                    myMouseArgs.clicDroit = true;
                    break;
                default:
                    break;
            }
           SourisHandler(this, myMouseArgs);
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
           
            if (e.X - myMouseArgs.x > 20)
            {
                myMouseArgs.mouvementVersLaDroite = true;
            }
            else
            {
                myMouseArgs.mouvementVersLaDroite = false;
            }
            myMouseArgs.x = e.X;
            SourisHandler(this, myMouseArgs);
        }

        /*
        private void mouseHoverBouton(object sender, EventArgs e)
        {
            Button tuile = (Button)sender;

            tuile.Text = "hover";
        }

        private void mouseLeaveBouton(object sender, EventArgs e)
        {
            Button tuile = (Button)sender;

            tuile.Text = tuile.Name;
        }
         * */
    }
}