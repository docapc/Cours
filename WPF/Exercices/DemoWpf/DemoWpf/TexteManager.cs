using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWpf
{
    public class TexteManager
    {
        public List<Texte> Textes { get; set; } = new List<Texte>() { new Texte("azer"), new Texte("ty") };

        public TexteManager()
        {

        }

    }
}
