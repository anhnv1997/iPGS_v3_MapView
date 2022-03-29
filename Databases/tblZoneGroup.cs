using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Databases
{
    public class tblZoneGroup
    {
        public static string TBL_NAME = "tblZoneGroup";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_NAME = "Name";
        public static string TBL_COL_CODE = "Code";
        public static string TBL_COL_DESCRIPTION = "Description";
        public static string TBL_COL_FLOOR_ID = "FloorID";
        public static string TBL_COL_SORT = "Sort";
        public static string GetCMD = $"Select {TBL_COL_ID},{TBL_COL_NAME},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_FLOOR_ID} from {TBL_NAME} order by {TBL_COL_SORT}";

        public string ID { get; set; }
        public int Sort { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string FloorID { get; set; }

        //Get
        public static ZoneGroupCollection LoadDataGroup(ZoneGroupCollection zgCollection)
        {
            DataTable dtZg = StaticPool.mdb.FillData(GetCMD);
            zgCollection.Clear();
            if (dtZg != null)
            {
                if (dtZg.Rows.Count > 0)
                {
                    foreach (DataRow row in dtZg.Rows)
                    {
                        ZoneGroup zoneGroup = new ZoneGroup();
                        zoneGroup.Id = row[TBL_COL_ID].ToString();
                        zoneGroup.Code = row[TBL_COL_CODE].ToString();
                        zoneGroup.Description = row[TBL_COL_DESCRIPTION].ToString();
                        zoneGroup.FloorID = row[TBL_COL_FLOOR_ID].ToString();
                        zoneGroup.Name = row[TBL_COL_NAME].ToString();
                        zgCollection.Add(zoneGroup);
                    }
                    dtZg.Dispose();
                    return zgCollection;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(string code, string description, string floorID, string zoneGroupName)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CODE},{TBL_COL_DESCRIPTION},
                                                         {TBL_COL_FLOOR_ID},{TBL_COL_NAME})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{code}',N'{description}','{floorID}',N'{zoneGroupName}')
                                  Select * from @generated_keys";
            DataTable dtbLastID = StaticPool.mdb.FillData(insertCMD);
            if ((dtbLastID == null))
            {
                dtbLastID = StaticPool.mdb.FillData(insertCMD);
                if ((dtbLastID == null))
                {
                    return "";
                }
            }
            return dtbLastID.Rows[0][TBL_COL_ID].ToString();
        }
        //Modify
        public static bool Modify(string id, string code, string description, string floorID, string zoneGroupName)
        {
            string modifyCMD = $@"update {TBL_NAME} 
                                  set {TBL_COL_CODE} = N'{code}',
                                      {TBL_COL_DESCRIPTION} = N'{description}',
                                      {TBL_COL_FLOOR_ID} = '{floorID}',
                                      {TBL_COL_NAME} = N'{zoneGroupName}' 
                                  Where {TBL_COL_ID} = '{id}'";
            if (!StaticPool.mdb.ExecuteCommand(modifyCMD))
            {
                if (!StaticPool.mdb.ExecuteCommand(modifyCMD))
                {
                    return false;
                }
            }
            return true;
        }
        //Delete
        public static bool Delete(string groupID)
        {
            string deleteCMD = $"Delete {TBL_NAME} where {TBL_COL_ID} = '{groupID}'";
            if (!StaticPool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!StaticPool.mdb.ExecuteCommand(deleteCMD))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
