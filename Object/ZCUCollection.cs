using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MapView
{
    public class ZCUCollection : CollectionBase
    {
        // Constructor
        public ZCUCollection()
        {

        }
        public ZCU this[int index]
        {
            get { return (ZCU)InnerList[index]; }
        }
        // Add
        public void Add(ZCU zcu)
        {
            InnerList.Add(zcu);
        }
        // Remove
        public void Remove(ZCU zcu)
        {
            InnerList.Remove(zcu);
        }
        // Get zcu by it's zcuID
        public ZCU GetZCUById(string zcuId)
        {
            foreach (ZCU zcu in InnerList)
            {
                if (zcu.Id == zcuId)
                {
                    return zcu;
                }
            }
            return null;
        }
        public ZCU GetZCUByIP(string zcuIp)
        {
            foreach (ZCU zcu in InnerList)
            {
                if (zcu.IPAddress == zcuIp)
                {
                    return zcu;
                }
            }
            return null;
        }
        public ZCU GetZCUByType(int Type)
        {
            foreach (ZCU zcu in InnerList)
            {
                if (zcu.Type == Type)
                {
                    return zcu;
                }
            }
            return null;
        }
        // Get zcu by it's address
        public ZCU GetZCUByAddress(int address)
        {
            foreach (ZCU zcu in InnerList)
            {
                if (zcu.Address == address)
                {
                    return zcu;
                }
            }
            return null;
        }
    }
}