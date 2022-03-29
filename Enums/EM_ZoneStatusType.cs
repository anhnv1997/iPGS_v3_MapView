using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iParking.Enums
{
    public class ZoneStatus{
        public static EM_ZoneStatusType GetZoneStatus(string zoneStatus)
        {
            switch (zoneStatus)
            {
                case "00":
                    return EM_ZoneStatusType.UN_OCCUPIED;
                case "01":
                    return EM_ZoneStatusType.OCCUPIED;
                case "10":
                    return EM_ZoneStatusType.DISCONNECT;
                default:
                    return EM_ZoneStatusType.UNKNOWN;
            }
        }
    }
    public enum EM_ZoneStatusType
    {
        UN_OCCUPIED,
        OCCUPIED,
        DISCONNECT,
        ORDER,
        UNKNOWN
    }
}
