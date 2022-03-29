using MapView.Object;
using System;
using System.Data;

namespace MapView.Databases
{
    public class tblMAP
    {
        public static string TBL_COL_NAME = "Name";
        public static string TBL_NAME = "tblMap";
        public static string TBL_COL_SORT = "Sort";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_CODE = "Code";
        public static string TBL_COL_DESCRIPTION = "Description";
        public static string TBL_COL_IMAGEPATH = "ImagePath";
        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_NAME},{TBL_COL_IMAGEPATH} 
                                                        from dbo.{TBL_NAME} order by {TBL_COL_SORT} ";

        public string ID { get; set; }
        public int Soft { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public static MapCollection LoadDataMap(MapCollection mapCollection)
        {
            
            DataTable dtMap = StaticPool.mdb.FillData(GetCMD);
            mapCollection.Clear();
            if (dtMap != null)
            {
                if (dtMap.Rows.Count > 0)
                {
                    foreach (DataRow row in dtMap.Rows)
                    {
                        Map map = new Map();
                        map.ID = row[TBL_COL_ID].ToString();
                        map.Code = row[TBL_COL_CODE].ToString();
                        map.Description = row[TBL_COL_DESCRIPTION].ToString();
                        map.Name = row[TBL_COL_NAME].ToString();
                        map.ImagePath = row[TBL_COL_IMAGEPATH].ToString();
                        mapCollection.Add(map);
                    }
                    dtMap.Dispose();
                    return mapCollection;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(string code, string description, string mapName, string imagePath)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_NAME},{TBL_COL_IMAGEPATH})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{code}',N'{description}',N'{mapName}',N'{imagePath}')
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
        public static bool Modify(string id, string code, string description, string floorName, string imagePath)
        {
            string modifyCMD = $@"update {TBL_NAME} 
                                  set {TBL_COL_CODE}=N'{code}',
                                      {TBL_COL_DESCRIPTION}=N'{description}',
                                      {TBL_COL_NAME}='{floorName}',
                                      {TBL_COL_IMAGEPATH}=N'{imagePath}' 
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
        public static bool Delete(string floorID)
        {
            string deleteCMD = $"Delete {TBL_NAME} where {TBL_COL_ID}='{floorID}'";
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
