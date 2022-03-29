using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace MapView
{
    public class ZONECollection : CollectionBase
    {
        // Constructor
        public ZONECollection()
        {

        }
        public ZONE this[int index]
        {
            get { return (ZONE)InnerList[index]; }
        }
        // Add
        public void Add(ZONE zone)
        {
            InnerList.Add(zone);
        }
        // Remove
        public void Remove(ZONE zone)
        {
            InnerList.Remove(zone);
        }
        // Get zone by it's zoneID
        public ZONE GetZONE(string zoneId)
        {
            foreach (ZONE zone in InnerList)
            {
                if (zone.Id == zoneId)
                {
                    return zone;
                }
            }
            return null;
        }
    }
}
