using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fisheye
{
    class Dimension
    {
        private int hauteur;
        private int largeur;

        public Dimension() {}

        public Dimension(int hauteur, int largeur)
        {
            this.setLargeur(hauteur);
            this.setLargeur(largeur);
        }

        public void setHauteur(int hauteur)
        {
            this.hauteur = hauteur;
        }

        public void setLargeur(int largeur)
        {
            this.largeur = largeur;
        }

        public int getHauteur()
        {
            return this.hauteur;
        }

        public int getLargeur()
        {
            return this.largeur;
        }
    }
}
