using Fisheye;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fisheye
{
    class Grille
    {
        private int ID = 0;
        public Size dimension;
        public List<Tuile> tuiles = new List<Tuile>();
       
        public Grille() { }

        public void ajouterTuile(Tuile tuile)
        {
            this.tuiles.Add(tuile);
            //this.majDimension();
            ID++;
        }

        public int getID()
        {
            return ID;
        }

        private void majDimension()
        {
            int hauteur = 0;
            int largeur = 0;
            int x = 0, y = 0;

            bool first = true;

            foreach (Tuile t in tuiles)
            {
                if (first)
                {
                    x = t.position.X;
                    y = t.position.Y;
                }

                if (t.position.X == x && t.position.Y == y)
                {
                    largeur += t.size.Width;
                    hauteur += t.size.Height;
                }
            }

            dimension = new Size(largeur, hauteur);
        }

        public void sauvegarderGrille(String nomFichier)
        {
            //On crée un nouveau XmlTextWriter
            XmlTextWriter docxml;
            docxml = new XmlTextWriter(nomFichier, System.Text.Encoding.UTF8);
            docxml.Formatting = Formatting.Indented;

            //On écrit la première ligne avec les spécifications du document XML
            docxml.WriteStartDocument();

            //on écrit le noeud racine du document
            docxml.WriteStartElement("Grille");

            foreach (Tuile t in tuiles)
            {
                //On écrit la première Tuile
                docxml.WriteStartElement("Tuile");

                //On écrit l'attribut "nom" de la première tuile
                docxml.WriteAttributeString("Nom", t.nom);

                //On écrit la propriété ""
                docxml.WriteStartElement("Couleur");
                docxml.WriteString(ColorTranslator.ToHtml(t.couleur));
                docxml.WriteEndElement();

                //On écrit la première propriété "Position X puis Y"
                docxml.WriteStartElement("X");
                docxml.WriteString(t.position.X + "");
                docxml.WriteEndElement();

                docxml.WriteStartElement("Y");
                docxml.WriteString(t.position.Y + "");
                docxml.WriteEndElement();

                docxml.WriteStartElement("Largeur");
                docxml.WriteString(t.size.Width + "");
                docxml.WriteEndElement();

                docxml.WriteStartElement("Hauteur");
                docxml.WriteString(t.size.Height + "");
                docxml.WriteEndElement();

                //On ferme la balise Tuile
                docxml.WriteEndElement();
            }

            //On ferme la balise Grille
            docxml.WriteEndElement();

            docxml.Close();
        }

        public void chargerTuiles(String chemin)
        {
            XmlTextReader docxml = new XmlTextReader(chemin);
            
            docxml.WhitespaceHandling = WhitespaceHandling.None;

            docxml.Read();
            docxml.Read();

            Tuile t;

            while (docxml.Read())
            {
                if (docxml.NodeType == XmlNodeType.Element)
                {
                    String nom = docxml.GetAttribute("Nom");

                    docxml.Read();
                    docxml.Read();
                    String couleur = docxml.Value;

                    docxml.Read();
                    docxml.Read();
                    docxml.Read();
                    String strX = docxml.Value;

                    docxml.Read();
                    docxml.Read();
                    docxml.Read();
                    String strY = docxml.Value;

                    docxml.Read();
                    docxml.Read();
                    docxml.Read();
                    String strLargeur = docxml.Value;

                    docxml.Read();
                    docxml.Read();
                    docxml.Read();
                    String strHauteur = docxml.Value;

                    int largeur = int.Parse(strLargeur);
                    int hauteur = int.Parse(strHauteur);

                    int x = int.Parse(strX);
                    int y = int.Parse(strY);

                    t = new Tuile(ID, nom, ColorTranslator.FromHtml(couleur), new Point(x, y), new Size(largeur, hauteur));

                    ajouterTuile(t);

                    docxml.Read();
                    docxml.Read();
                }
            }
        }

        public String toString()
        {
            String chaine = "Grille : \n";

            foreach (Tuile t in tuiles)
            {
                 chaine += "Tuile : " + t.nom + ", " + t.couleur + "\n";
            }

            return chaine;
        }
    }
}
