using System;
using System.Collections.Generic;
using System.Text;

namespace MapView
{
    // Zone Group
    public class ZoneGroup
    {
        // Constructor
        public ZoneGroup()
        {

        }
        public string Name { get; set; }
        private string id = "";
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
        private string zoneID = "";
        public string ZoneID { get => zoneID; set => zoneID = value; }

        private string floorID = "";
        public string FloorID { get => floorID; set => floorID = value; }
    }
}
