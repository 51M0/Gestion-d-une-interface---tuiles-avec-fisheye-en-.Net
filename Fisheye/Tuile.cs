using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisheye
{
    public class Tuile
    {
        private int id;
        public String nom;
        public Color couleur;
        public Point position;
        public Size size;

        public Tuile() {}

        public Tuile(int id, String nom, Color couleur, Point position, Size dimension)
        {
            this.id         = id;
            this.nom        = nom;
            this.couleur    = couleur;
            this.position   = position;
            this.size       = dimension;
        }

        public int getId()
        {
            return id;
        }
    }
}
