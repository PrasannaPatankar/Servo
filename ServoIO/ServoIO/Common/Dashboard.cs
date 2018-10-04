using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ServoIO.Common
{
    public class Dashboard
    {
        public string Title { get; set; }
        public ImageSource Icon { get; set; }
        public string SubTitle { get; set; }
        public int TileOrder { get; set; }
        public Color TileColor { get; set; }
    }
}
