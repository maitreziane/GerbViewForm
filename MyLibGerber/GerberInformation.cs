using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyLibGerber
{
    class GerberInformation
    {
        private BufferedGraphicsContext context;
        
        

        public GerberInformation(Size panelDraw_size)
        {
            this.context = BufferedGraphicsManager.Current;
            this.context.MaximumBuffer = panelDraw_size;
            
        }

        public BufferedGraphicsContext Context
        {
            get   { return context; }
        }
    }
}
