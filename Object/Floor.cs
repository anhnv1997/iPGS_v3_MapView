using MapView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Object
{
    public class Floor
    {
        private string id = "";
        public string Name { get; set; }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code = "";
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string description = "";
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public ZoneGroupCollection ZgCollection { get; set; }
    }
}
