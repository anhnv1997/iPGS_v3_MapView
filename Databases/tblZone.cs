using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Databases
{
    public class tblZone
    {
        public static string TBL_NAME = "tblZone";
        public static string TBL_COL_SORT = "Sort";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_CODE = "Code";
        public static string TBL_COL_DESCRIPTION = "Description";
        public static string TBL_COL_ZCUID = "ZCUID";
        public static string TBL_COL_GROUP_ID = "GroupID";
        public static string TBL_COL_STATUS = "Status";
        public static string TBL_COL_IMG_SAVEPATH = "ImageSavePath";
        public static string TBL_COL_NAME = "Name";
        public static string TBL_COL_PLATENUM = "PlateNum";
        public static string TBL_COL_ZCU_INDEX = "zcuIndex";
        public static string TBL_COL_ORDER_PLATENUM = "OrderPlateNum";
        public string ID { get; set; }
        public int Sort { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ZCUID { get; set; }
        public string GroupID { get; set; }
        public int Status { get; set; }
        public string ImageSavePath { get; set; }
        public string plateNum { get; set; }
        public int ZcuIndex { get; set; }
        public string OrderPlateNumber { get; set; }
        public static string GetCMD = @$"Select {TBL_COL_ID},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_ZCUID}, 
                                                               {TBL_COL_GROUP_ID},{TBL_COL_STATUS},{TBL_COL_IMG_SAVEPATH},
                                                               {TBL_COL_PLATENUM},{TBL_COL_NAME},{TBL_COL_ZCU_INDEX},
                                                               {TBL_COL_ORDER_PLATENUM}
                                                          from dbo.{TBL_NAME}
                                                          order by {TBL_COL_SORT}";

        //Get
        public static ZONECollection LoadDataZone(ZONECollection zoneCollection)
        {
            DataTable dtZone = StaticPool.mdb.FillData(GetCMD);
            zoneCollection.Clear();
            if (dtZone != null)
            {
                if (dtZone.Rows.Count > 0)
                {
                    foreach (DataRow row in dtZone.Rows)
                    {
                        ZONE zone = new ZONE();
                        zone.Id = row[TBL_COL_ID].ToString();
                        zone.Code = row[TBL_COL_CODE].ToString();
                        zone.Description = row[TBL_COL_DESCRIPTION].ToString();
                        zone.ZCUId = row[TBL_COL_ZCUID].ToString();
                        zone.ZoneGroupId = row[TBL_COL_GROUP_ID].ToString();
                        zone.Status = Convert.ToInt32(row[TBL_COL_STATUS].ToString());
                        zone.OldStatus = zone.Status;
                        zone.ImagePath = row[TBL_COL_IMG_SAVEPATH].ToString();
                        zone.PlateNum = row[TBL_COL_PLATENUM].ToString();
                        zone.zoneName = row[TBL_COL_NAME].ToString();
                        zone.ZcuIndex = Convert.ToInt32(row[TBL_COL_ZCU_INDEX].ToString());
                        zone.OrderPlateNumber = row[TBL_COL_ORDER_PLATENUM].ToString();
                        zoneCollection.Add(zone);
                    }
                    dtZone.Dispose();
                    return zoneCollection;
                }
            }
            return null;
        }
    }
}
