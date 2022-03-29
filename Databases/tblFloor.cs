using MapView.Object;
using System;
using System.Data;

namespace MapView.Databases
{
    public class tblFloor
    {
        public static string TBL_NAME = "tblFloor";
        public static string TBL_COL_NAME = "Name";
        public static string TBL_COL_SORT = "Sort";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_CODE = "Code";
        public static string TBL_COL_DESCRIPTION = "Description";

        public static string GetCMD = $@"Select {TBL_COL_ID},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_NAME} 
                               from dbo.{TBL_NAME} order by {TBL_COL_SORT}";
        public int Sort { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }


        //Get
        public static FloorCollection LoadDataFloor(FloorCollection floorCollection)
        {
            
            DataTable dtFloor = StaticPool.mdb.FillData(GetCMD);
            floorCollection.Clear();
            if (dtFloor != null)
            {
                if (dtFloor.Rows.Count > 0)
                {
                    foreach (DataRow row in dtFloor.Rows)
                    {
                        Floor floor = new Floor();
                        floor.Id = row[TBL_COL_ID].ToString();
                        floor.Code = row[TBL_COL_CODE].ToString();
                        floor.Description = row[TBL_COL_DESCRIPTION].ToString();
                        floor.Name = row[TBL_COL_NAME].ToString();
                        floorCollection.Add(floor);
                    }
                    dtFloor.Dispose();
                    return floorCollection;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(string code, string description, string floorName)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_NAME})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{code}',N'{description}',N'{floorName}')
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
        public static bool Modify(string id, string code, string description,string floorName)
        {
            string modifyCMD = $"update {TBL_NAME} set {TBL_COL_CODE}=N'{code}',{TBL_COL_DESCRIPTION}=N'{description}',{TBL_COL_NAME}='{floorName}' Where {TBL_COL_ID} = '{id}'";
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
            if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{floorID}'"))
            {
                if (!StaticPool.mdb.ExecuteCommand($"Delete {TBL_NAME} where {TBL_COL_ID}='{floorID}'"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
