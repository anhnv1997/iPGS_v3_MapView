using System;
using System.Collections.Generic;
using System.Text;

namespace MapView
{
    public class ZONE
    {
        // Constructor
        public ZONE()
        {

        }
        public string zoneName { get; set; }
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

        private int address = 0;
        public int Address
        {
            get { return address; }
            set { address = value; }
        }
        private string zcuId = "";
        public string ZCUId
        {
            get { return zcuId; }
            set { zcuId = value; }
        }

        private int zcuIndex = 0;
        public int ZcuIndex { get => zcuIndex; set => zcuIndex = value; }

        private string zoneGroupID = "";
        public string ZoneGroupId
        {
            get { return zoneGroupID; }
            set { zoneGroupID = value; }
        }
        private string mapID = "";
        public string MapID { get => mapID; set => mapID = value; }
        // 2-Cho trong, 3-Co xe, 4-Khong ket noi duoc den thiet bi
        private int status = -1;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        private int oldstatus = -1;
        public int OldStatus
        {
            get { return oldstatus; }
            set { oldstatus = value; }
        }
        public string ImagePath { get; set; }
        public string PlateNum { get; set; }
        public string ZoneGroupName { get; set; }   
        public string MapName { get; set; }
        public string ZcuName { get; set; }
        public string OrderPlateNumber { get; set; }
        public string VehicleTypeID { get; set; }
    }
}
