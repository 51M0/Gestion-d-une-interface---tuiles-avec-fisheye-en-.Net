using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fisheye
{
    public partial class Form2 : Form
    {
        Button tuilePrincipale;

        List<Button> tuiles = new List<Button>();

        List<Button> listeAChanger = new List<Button>();

        List<Tuile> modeles = new List<Tuile>();

        int ecartX;
        int ecartY;

        int distanceFocus;


        public Form2(List<Button> tuiles, List<Tuile> modeles)
        {
            InitializeComponent();

            this.tuiles  = tuiles;
            this.modeles = modeles;

            dessinerGrille(this.tuiles);
        }

        private void dessinerGrille(List<Button> tuiles)
        {
         

            foreach (var item in tuiles)
            {
                this.Controls.Add(item);
                canvas.Controls.Add(item);

                item.MouseHover     += new EventHandler(activer_fisheye);
                item.MouseLeave   += desactiver_fisheye;
            }
        }


       
        public void modificationTuile(Button t)
        {
            Point centreT = pointCentral(t);
            Point centrePrincipale = pointCentral(tuilePrincipale);
            Point[] coinsPrincipale = tabCoins(tuilePrincipale);

            if (centreT.X <= centrePrincipale.X) //si c'est à gauche
            {
                //On regarde si c'est en haut ou en bas
                if (centreT.Y <= centrePrincipale.Y)
                {
                    //Si c'est en haut à gauche
                    //On regarde le coin haut gauche de la tuile principale
                    if (coinsPrincipale[0].X >= centreT.X)
                    {
                        //Appliquer ecartX sur tuile t
                        modifTailleTuile(t, ecartX, 0);
                    }
                    if (coinsPrincipale[0].Y >= centreT.Y)
                    {
                        //Appliquer ecartY sur tuile t
                        modifTailleTuile(t, 0, ecartY);
                    }
                }
                else
                {

                    if (coinsPrincipale[3].X <= centreT.X && coinsPrincipale[3].Y >= centreT.Y)
                    {
                        modifTailleTuile(t, ecartX, 0);
                        modifTailleTuile(t, 0, ecartY);
                        decalageTuile(t, ecartY, 0);
                    }
                    //Si c'est en bas à gauche
                    //On regarde le coin bas gauche de la tuile principale
                    if (coinsPrincipale[3].X > centreT.X)
                    {
                        modifTailleTuile(t, ecartX, 0);
                    }
                    if (coinsPrincipale[3].Y < centreT.Y)
                    {
                        //fonction decaler en bas
                        modifTailleTuile(t, 0, ecartY);
                        decalageTuile(t, ecartY, 0);
                    }
                }
            }
            else
            {
                //Si c'est à droite
                //On regarde si c'est en haut ou en bas
                if (centreT.Y <= centrePrincipale.Y)
                {
                    //Si c'est en haut à droite
                    //On regarde le coin haut droite de la tuile principale
                    if (coinsPrincipale[1].X <= centreT.X && coinsPrincipale[1].Y >= centreT.Y)
                    {
                        modifTailleTuile(t, 0, ecartY);
                        //Appliquer ecartX sur tuile t
                        modifTailleTuile(t, ecartX, 0);
                        //faire une fonction décaler en plus
                        decalageTuile(t, 0, ecartX);
                    }

                    if (coinsPrincipale[1].X > centreT.X)
                        modifTailleTuile(t, 0, ecartY);

                    if (coinsPrincipale[1].Y < centreT.Y)
                    {
                        //Appliquer ecartX sur tuile t
                        modifTailleTuile(t, ecartX, 0);
                        //faire une fonction décaler en plus
                        decalageTuile(t, 0, ecartX);
                    }
                }
                else
                {
                    //Si c'est en bas à droite
                    //On regarde le coin bas droite de la tuile principale
                    //faire fonction decaler pour descendre

                    if (coinsPrincipale[2].X <= centreT.X && coinsPrincipale[2].Y <= centreT.Y)
                    {
                        modifTailleTuile(t, 0, ecartY);
                        decalageTuile(t, ecartY, 0);
                        //Appliquer ecartX sur tuile t
                        modifTailleTuile(t, ecartX, 0);
                        //faire une fonction décaler en plus
                        decalageTuile(t, 0, ecartX);
                    }

                    if (coinsPrincipale[2].X > centreT.X)
                    {
                        modifTailleTuile(t, 0, ecartY);
                        decalageTuile(t, ecartY, 0);
                    }

                    if (coinsPrincipale[2].Y > centreT.Y)
                    {
                        //Appliquer ecartX sur tuile t
                        modifTailleTuile(t, ecartX, 0);
                        //faire une fonction décaler en plus
                        decalageTuile(t, 0, ecartX);
                    }
                }
            }
        }

        private Point pointCentral(Button t)
        {
            return new Point(t.Location.X + t.Width / 2, t.Location.Y + t.Height / 2);
        }

        public Point[] tabCoins(Button t)
        {
            Point[] tableau = new Point[4];
            Point p = new Point();

            p.X = t.Location.X;   //haut gauche
            p.Y = t.Location.Y;
            tableau[0] = p;

            p.X = t.Location.X + t.Width;    //haut droit
            p.Y = t.Location.Y;
            tableau[1] = p;

            p.X = t.Location.X + t.Width;  //bas droit
            p.Y = t.Location.Y + t.Height;
            tableau[2] = p;

            p.X = t.Location.X;             //bas gauche
            p.Y = t.Location.Y + t.Height;
            tableau[3] = p;


            return tableau;
        }

        public void modifTailleTuile(Button t, int ecartX, int ecartY)
        {
            t.Width = t.Width - ecartX;
            t.Height = t.Height - ecartY;
        }

        public void decalageTuile(Button t, int decalageBas, int decalageDroite)
        {
            Point nouvPoint = new Point(t.Location.X + decalageDroite, t.Location.Y + decalageBas);
            t.Location = nouvPoint;
        }

        public void decalageTuile(Tuile t, int decalageBas, int decalageDroite)
        {
            Point nouvPoint = new Point(t.position.X + decalageDroite, t.position.Y + decalageBas);
            t.position      = nouvPoint;
        }

        private void activer_fisheye(object sender, EventArgs e)
        {
            int nouvHauteur, nouvLargeur;
            Point centre = new Point();

            Button button = (Button)sender;
            tuilePrincipale = button;
           
            
            nouvHauteur = Convert.ToInt32(button.Height * 1.25);
            nouvLargeur = Convert.ToInt32(button.Width * 1.25);

            ecartX = (nouvLargeur - button.Width) / 2;
            ecartY = (nouvHauteur - button.Height) / 2;

            centre = pointCentral(button);
            distanceFocus = (int)distance(button.Location, centre) + ((ecartY + ecartX) / 2);

            Point nouvPoint = new Point(button.Location.X - ecartX, button.Location.Y - ecartY);
            button.Location = nouvPoint;

            aChanger(centre, distanceFocus);

            button.Height = nouvHauteur;
            button.Width = nouvLargeur;
            button.Font = new Font(button.Font.FontFamily,16,FontStyle.Bold);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Cyan;
            button.FlatAppearance.BorderSize = 4;
        }

        
        private void desactiver_fisheye(object sender, EventArgs e)
        {
            //listeTuile = listeTuileBis;

            for (int i = 0; i < tuiles.Count; i++)
            {
                tuiles[i].Location  =   modeles[i].position;
                tuiles[i].Height    =   modeles[i].size.Height;
                tuiles[i].Width     =   modeles[i].size.Width;
                tuiles[i].Font = new Font(tuiles[i].Font.FontFamily, 10, FontStyle.Regular);
                tuiles[i].FlatStyle = FlatStyle.Standard;
                

            }

        }
        

        public void pointer(Button t, Point p, double d)
        {
            Point tuilePoint = new Point();
            tuilePoint.X = t.Location.X;
            tuilePoint.Y = t.Location.Y;
            double dist;
            listeAChanger = new List<Button>();
            Point[] tableau = new Point[4];
            tableau = tabCoins(t);
            bool focus = false;
            Console.WriteLine("d: " + d);


            for (int i = 0; i < 4; i++)
            {
                dist = distance(tableau[i], p);

                if (dist <= d)
                {
                    focus = true;
                }
            }
            if (focus)
            {
                modificationTuile(t);
            }
        }

        public void aChanger(Point p, double dist)
        {
            foreach (Button t in tuiles)
            {
                pointer(t, p, dist);
            }
        }

        private double distance(Point p1, Point p2)
        {
            double distance = 0;

            distance = Math.Sqrt(Sqr(p1.X - p2.X) + Sqr(p1.Y - p2.Y));

            return distance;
        }

        public double Sqr(double a)
        {
            return a * a;
        }
    }
}