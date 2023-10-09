using System.Collections.Generic;

namespace Sefin.Security
{
    public class Item
    {
        public int id { get; set; }
        public string nombre { get; set; }
        private string _icon=string.Empty;
        private string _url;
        public string label { get; set; }

        public string url
        {
            get
            {
                return _url ?? string.Empty;
            }
            set { _url = value; }
        }

        public string icon
        {
            get
            {
                return _icon ?? string.Empty;
            }
            set { _icon = value; }
        }

        public IEnumerable<Item> childs { get; set; }

    }
}