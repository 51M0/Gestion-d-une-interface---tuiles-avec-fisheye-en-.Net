using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fisheye
{
    public partial class ModifierTuile : Form
    {
        public Button tuile;
        Fisheye parent;
        int idTuile;

        public ModifierTuile(Fisheye parent, int idTuile, String nom, int largeur, int hauteur, Color couleur)
        {
            InitializeComponent();

            this.parent                     =   parent;
            this.idTuile                    =   idTuile;
            this.zoneNom.Text               =   nom;
            this.zoneHauteur.Value          =   hauteur;
            this.zoneLargeur.Value          =   largeur;
            this.colorDialog1.Color         =   couleur;
            this.boutonCouleur.BackColor    =   couleur;
        }

        private void boutonAjouter_Click(object sender, EventArgs e)
        {
            tuile = new Button();

            tuile.AllowDrop = true;
            tuile.BackColor = boutonCouleur.BackColor;
            tuile.Name      = zoneNom.Text;
            tuile.Size      = new System.Drawing.Size((int)(50 * zoneLargeur.Value), (int)(50 * zoneHauteur.Value));
            tuile.Text      = zoneNom.Text;

            Fisheye parent = this.Owner as Fisheye;

            this.parent.modifierTuile(tuile, idTuile);

            this.Close();
        }

        private void boutonCouleur_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                boutonCouleur.BackColor = colorDialog1.Color;
            }
        }

        private void boutonSupprimer_Click(object sender, EventArgs e)
        {
            this.parent.supprimerTuile(tuile, idTuile);
            this.Close();
        }
    }
}
