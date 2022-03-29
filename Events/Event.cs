using iParking.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.Events
{
    public delegate void DeleteZoneInMapHandler(object sender, DeleteZoneInMapEventArgs e);
    public delegate void ShowMapDetailInfor(object sender, ShowMapDetailInforEventArgs e);
    public delegate void ZoneEvent(object sender, ZoneEventArgs e);
    public delegate void WarningEvent(object sender, WarningEventArgs e);
    public delegate void StatusChangeEvent(object sender, ZCUStatusEventArgs e);
    public delegate void ChangeLedDisplayEvent(object sender, ChangeLedDisplayEventArgs e);
    public class ZCUStatusEventArgs: EventArgs
    {
        public string ZCUID { get; set; }
        public string Status { get; set; }
    }

    public class WarningEventArgs
    {
        public string ZoneID;
        public string OrderPlateNumber;
        public string CurrentPlateNumber;
    }

    public class DeleteZoneInMapEventArgs : EventArgs
    {
        public DeleteZoneInMapEventArgs()
        {
        }
        public string ZoneID { get; set; }
        public string MapID { get; set; }
        public DeleteZoneInMapEventArgs(string _zoneID, string _mapID)
        {
            this.ZoneID = _zoneID;
            this.MapID = _mapID;
        }
    }

    public class ShowMapDetailInforEventArgs
    {
        public string zoneID;
        public string zcuID;
        public string mapID;
        public int zoneStatus;
        public string imagePath;
        public string plateNum;
    }

    public class ZoneEventArgs
    {
        private string zoneID;
        private string zcuID;
        private EM_ZoneStatusType zoneStatus;

        public string ZoneID { get => zoneID; set => zoneID = value; }
        public string ZcuID { get => zcuID; set => zcuID = value; }
        public EM_ZoneStatusType ZoneStatus { get => zoneStatus; set => zoneStatus = value; }
    }

    public class ChangeLedDisplayEventArgs : EventArgs
    {
        public string ZoneName { get; set; }
        public string PlateNumber { get; set; }
    }
}
