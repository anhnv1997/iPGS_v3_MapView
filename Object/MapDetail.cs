using System;
using System.Collections.Generic;
using System.Text;

namespace MapView
{
    public class MapDetail
    {
        // Constructor
        public MapDetail()
        {

        }
        public string Description { get; set; }
        private string id = "";
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        // MapID property
        private string mapId = "";
        public string MapId
        {
            get { return mapId; }
            set { mapId = value; }
        }

        // ZONEId
        private string zoneId = "";
        public string ZONEId
        {
            get { return zoneId; }
            set { zoneId = value; }
        }

        // PosX property
        private double posX = 0.0;
        public double PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        // PosY property
        private double posY = 0.0;
        public double PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public int zoneWidth { get; set; }
        public int zoneHeight { get; set; }

        // Status
        private int status = 2;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int picMapWidth { get; set; }
        public int picMapHeight { get; set; }
    }
}
