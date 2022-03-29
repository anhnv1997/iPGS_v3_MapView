using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Databases
{
    public class tblMapDetail
    {
        public static string TBL_NAME = "tblMapDetail";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_MAPID = "MapID";
        public static string TBL_COL_ZONEID = "ZoneID";
        public static string TBL_COL_POSX = "ZonePosX";
        public static string TBL_COL_POSY = "ZonePosY";
        public static string TBL_COL_WIDTH = "ZoneWidth";
        public static string TBL_COL_HEIGHT = "ZoneHeight";
        public static string TBL_COL_MAP_WIDTH = "MapWidth";
        public static string TBL_COL_MAPHEIGHT = "MapHeight";
        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_MAPID},{TBL_COL_ZONEID},{TBL_COL_POSX},{TBL_COL_POSY},{TBL_COL_WIDTH},{TBL_COL_HEIGHT},{TBL_COL_MAP_WIDTH},{TBL_COL_MAPHEIGHT}
                                                               from dbo.{TBL_NAME}";
        
        public string ID { get; set; }
        public string MapID { get; set; }
        public string ZoneID { get; set; }
        public float ZonePosX { get; set; }
        public float ZonePosY { get; set; }
        public int ZoneWidth { get; set; }
        public int ZoneHeight { get; set; }
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        //Get
        public static MapDetailCollection LoadMapDetailData(MapDetailCollection mapDetailCollection)
        {
            
            DataTable dtMapDetail = StaticPool.mdb.FillData(GetCMD);
            mapDetailCollection.Clear();
            if (dtMapDetail != null)
            {
                if (dtMapDetail.Rows.Count > 0)
                {
                    foreach (DataRow row in dtMapDetail.Rows)
                    {
                        MapDetail mapDetail = new MapDetail();
                        mapDetail.Id = row[TBL_COL_ID].ToString();
                        mapDetail.MapId = row[TBL_COL_MAPID].ToString();
                        mapDetail.ZONEId = row[TBL_COL_ZONEID].ToString();
                        mapDetail.PosX = Convert.ToInt32(row[TBL_COL_POSX].ToString());
                        mapDetail.PosY = Convert.ToInt32(row[TBL_COL_POSY].ToString());
                        mapDetail.zoneWidth = Convert.ToInt32(row[TBL_COL_WIDTH].ToString());
                        mapDetail.zoneHeight = Convert.ToInt32(row[TBL_COL_HEIGHT].ToString());
                        mapDetail.picMapWidth = Convert.ToInt32(row[TBL_COL_MAP_WIDTH].ToString());
                        mapDetail.picMapHeight = Convert.ToInt32(row[TBL_COL_MAPHEIGHT].ToString());
                        mapDetailCollection.Add(mapDetail);
                    }
                    dtMapDetail.Dispose();
                    return mapDetailCollection;
                }
            }
            return null;
        }
        //Add
        //Delete
    }
}
