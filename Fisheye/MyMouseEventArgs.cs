using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fisheye
{
    public class MyMouseEventArgs : EventArgs
    {
      
        public Boolean clicGauche = false, clicDroit = false, mouvementVersLaDroite = false;
        public int x = 0;

       public MyMouseEventArgs()
        {
           
        }
        public Boolean mouvementValide()
        {
            return clicGauche && clicDroit && mouvementVersLaDroite;
        }
    }
}