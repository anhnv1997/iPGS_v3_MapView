using System;
using System.Collections.Generic;
using System.Text;

namespace MapView
{
    public class ZCU
    {
        // Constructor
        public ZCU()
        {

        }
        public string  ZcuName { get; set; }
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

        private string ccuId = "";
        public string CCUId
        {
            get { return ccuId; }
            set { ccuId = value; }
        }
        // Địa chỉ của Zone kết nôi đến ZCU
        private int address = 0;
        public int Address
        {
            get { return address; }
            set { address = value; }
        }
        
        private bool isConnect = false;
        public bool IsConnect
        {
            get { return isConnect; }
            set { isConnect = value; }
        }

        public string IPAddress { get; set; } = "";
        public int Port { get; set; } = 0;

        // count timeout if zcu disconnect
        public int Timeout { get; set; } = 0;
        private int _Type;
        public int Type { get; set; }
        private int communicationType = 0;
        public ZONECollection zoneCollection { get; set; }

        public bool StopGetEvent { get; set; } = false;
        #region: ZCU as camera
        private string message = "";
        public string Message { get; set; }

        private string imageBase64 = "";
        public int ImageBase64 { get; set; }
        private int totalSlot = 96;
        public int TotalSlot { get; set; }

        private int unOccupiedSlot = 96;
        public int UnOccupiedSlot { get; set; }

        private int disconnectSlot=0;
        public int DisconnectSlot { get; set; }

        private int occupiedSlot=0;
        public int OoccupiedSlot { get; set; }

        private string status;
        public string Status { get; set; }
        #endregion
        public string Username { get; set; }
        public int STT { get; set; }
        public string Password { get; set; }
        public int CommunicationType { get => communicationType; set => communicationType = value; }
        public string TMA_ID { get; set; }
        public int TMA_Index { get; set; }
        public int TMA_Cam_Type { get; set; }
    }
}
