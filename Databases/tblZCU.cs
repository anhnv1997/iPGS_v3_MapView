using System;
using System.Data;

namespace MapView
{
    public class tblZCU
    {
        public static string TBL_NAME = "tblZCU";
        public static string TBL_COL_SORT = "Sort";
        public static string TBL_COL_NAME = "Name";
        public static string TBL_COL_ID = "ID";
        public static string TBL_COL_CODE = "Code";
        public static string TBL_COL_DESCRIPTION = "Description";
        public static string TBL_COL_CCUID = "CCUID";
        public static string TBL_COL_ADDR = "Address";
        public static string TBL_COL_IP = "IPAddress";
        public static string TBL_COL_PORT = "Port";
        public static string TBL_COL_TYPE = "Type";
        public static string TBL_COL_USERNAME = "_Username";
        public static string TBL_COL_PASSWORD = "_Password";
        public static string TBL_COM_COMMUNICATION_TYPE = "CommunicationType";
        public static string TBL_COL_TMAID = "TMAID";
        public static string TBL_COL_TMAINDEX = "TMAIndex";
        public static string TBL_COL_TMA_CAM_TYPE = "TMA_Cam_Type";

        public static string GetCMD = @$"Select {TBL_COL_ID},{TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_CCUID}, 
                                                                {TBL_COL_ADDR},{TBL_COL_IP},{TBL_COL_PORT},{TBL_COL_TYPE},{TBL_COL_NAME},
                                                                {TBL_COL_USERNAME},{TBL_COL_PASSWORD},{TBL_COM_COMMUNICATION_TYPE},
                                                                {TBL_COL_TMAID},{TBL_COL_TMAINDEX},{TBL_COL_TMA_CAM_TYPE}
                                                        from dbo.{TBL_NAME} 
                                                        order by {TBL_COL_SORT}";

        public string ID { get; set; }
        public int Sort { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string CCUID { get; set; }
        public int Address { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public int Type { get; set; }
        public string _Username { get; set; }
        public string _Password { get; set; }
        public int CommunicationType { get; set; }
        public string TMAID { get; set; }
        public int TMAIndex { get; set; }
        public int TMA_Cam_Type { get; set; }

        //Get
        public static ZCUCollection LoadDataZCU(ZCUCollection zcuCollection)
        {
            DataTable dtZCU = StaticPool.mdb.FillData(GetCMD);
            zcuCollection.Clear();
            if (dtZCU != null)
            {
                if (dtZCU.Rows.Count > 0)
                {
                    foreach (DataRow row in dtZCU.Rows)
                    {
                        ZCU zcu = new ZCU();
                        zcu.Id = row[TBL_COL_ID].ToString();
                        zcu.Code = row[TBL_COL_CODE].ToString();
                        zcu.Description = row[TBL_COL_DESCRIPTION].ToString();
                        zcu.CCUId = row[TBL_COL_CCUID].ToString();
                        zcu.Address = Convert.ToInt32(row[TBL_COL_ADDR].ToString());
                        zcu.IPAddress = row[TBL_COL_IP].ToString();
                        zcu.Port = Convert.ToInt32(row[TBL_COL_PORT].ToString());
                        zcu.Type = Convert.ToInt32(row[TBL_COL_TYPE].ToString());
                        zcu.ZcuName = row[TBL_COL_NAME].ToString();
                        zcu.Username = row[TBL_COL_USERNAME].ToString();
                        zcu.Password = row[TBL_COL_PASSWORD].ToString();
                        zcu.CommunicationType = Convert.ToInt32(row[TBL_COM_COMMUNICATION_TYPE]);
                        zcu.TMA_ID = row[TBL_COL_TMAID].ToString();
                        zcu.TMA_Index = Convert.ToInt32(row[TBL_COL_TMAINDEX].ToString());
                        zcu.TMA_Cam_Type = row[TBL_COL_TMA_CAM_TYPE].ToString() == "" || row[TBL_COL_TMA_CAM_TYPE].ToString() == null ? 0 : Convert.ToInt32(row[TBL_COL_TMA_CAM_TYPE].ToString());
                        zcuCollection.Add(zcu);
                    }
                    dtZCU.Dispose();
                    return zcuCollection;
                }
            }
            return null;
        }
        //Add
        public static string InsertAndGetLastID(string code, string description, string ccuID, int addr, string ipAddr, int port, int type, string zcuName, string username, string password, int communicationType, string _TMAID, int _TMAIndex)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_CCUID},
                                                   {TBL_COL_ADDR},{TBL_COL_IP},{TBL_COL_PORT},{TBL_COL_TYPE},
                                                   {TBL_COL_NAME},{TBL_COL_USERNAME},{TBL_COL_PASSWORD},
                                                   {TBL_COM_COMMUNICATION_TYPE},{TBL_COL_TMAID},{TBL_COL_TMAINDEX})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{code}',N'{description}','{ccuID}',{addr},'{ipAddr}',{port},{type},
                                   N'{zcuName}','{username}','{password}',{communicationType},'{_TMAID}',{TBL_COL_TMAINDEX})
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
        public static string InsertAndGetLastID(ZCU zcu)
        {
            string insertCMD = $@"DECLARE @generated_keys table([{TBL_COL_ID}] varchar(150))
                                  Insert into {TBL_NAME}({TBL_COL_CODE},{TBL_COL_DESCRIPTION},{TBL_COL_CCUID},
                                                   {TBL_COL_ADDR},{TBL_COL_IP},{TBL_COL_PORT},{TBL_COL_TYPE},
                                                   {TBL_COL_NAME},{TBL_COL_USERNAME},{TBL_COL_PASSWORD},
                                                   {TBL_COM_COMMUNICATION_TYPE},{TBL_COL_TMAID},{TBL_COL_TMAINDEX},{TBL_COL_TMA_CAM_TYPE})
                                  OUTPUT inserted.{TBL_COL_ID} 
                                  Into @generated_keys
                                  values(N'{zcu.Code}',N'{zcu.Description}','{zcu.CCUId}',{zcu.Address},'{zcu.IPAddress}',{zcu.Port},{zcu.Type},
                                   N'{zcu.ZcuName}','{zcu.Username}','{zcu.Password}',{zcu.CommunicationType},'{zcu.TMA_ID}',{zcu.TMA_Index},{zcu.TMA_Cam_Type})
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
        public static bool Modify(string id, string code, string description, string ccuID, int addr, string ipAddr, int port, int type, string zcuName, string username, string password, int communicationType, string _TMAID, int _TMAIndex)
        {
            string cmd = @$"update {TBL_NAME} 
                            set {TBL_COL_CODE}=N'{code}',
                                {TBL_COL_DESCRIPTION}=N'{description}',
                                {TBL_COL_CCUID}='{ccuID}',
                                {TBL_COL_ADDR}={addr},
                                {TBL_COL_IP}='{ipAddr}',
                                {TBL_COL_PORT}={port},
                                {TBL_COL_TYPE}={type},
                                {TBL_COL_NAME}=N'{zcuName}',
                                {TBL_COL_USERNAME}='{username}',
                                {TBL_COL_PASSWORD}='{password}',
                                {TBL_COM_COMMUNICATION_TYPE}={communicationType},
                                {TBL_COL_TMAID}='{_TMAID}',
                                {TBL_COL_TMAINDEX}={_TMAIndex}
                            Where {TBL_COL_ID} = '{id}'";
            if (!StaticPool.mdb.ExecuteCommand(cmd))
            {
                if (!StaticPool.mdb.ExecuteCommand(cmd))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool Modify(ZCU zcu)
        {
            string cmd = @$"update {TBL_NAME} 
                            set {TBL_COL_CODE}=N'{zcu.Code}',
                                {TBL_COL_DESCRIPTION}=N'{zcu.Description}',
                                {TBL_COL_CCUID}='{zcu.CCUId}',
                                {TBL_COL_ADDR}={zcu.Address},
                                {TBL_COL_IP}='{zcu.IPAddress}',
                                {TBL_COL_PORT}={zcu.Port},
                                {TBL_COL_TYPE}={zcu.Type},
                                {TBL_COL_NAME}=N'{zcu.ZcuName}',
                                {TBL_COL_USERNAME}='{zcu.Username}',
                                {TBL_COL_PASSWORD}='{zcu.Password}',
                                {TBL_COM_COMMUNICATION_TYPE}={zcu.CommunicationType},
                                {TBL_COL_TMAID}='{zcu.TMA_ID}',
                                {TBL_COL_TMAINDEX}={zcu.TMA_Index},
                                {TBL_COL_TMA_CAM_TYPE} = {zcu.TMA_Cam_Type}
                            Where {TBL_COL_ID} = '{zcu.Id}'";
            if (!StaticPool.mdb.ExecuteCommand(cmd))
            {
                if (!StaticPool.mdb.ExecuteCommand(cmd))
                {
                    return false;
                }
            }
            return true;
        }

        //Delete
        public static bool Delete(string zcuID)
        {
            string deleteCMD = $"Delete {TBL_NAME} where {TBL_COL_ID} = '{zcuID}'";
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
