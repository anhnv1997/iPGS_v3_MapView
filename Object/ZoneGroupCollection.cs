using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MapView
{
    public class ZoneGroupCollection:CollectionBase
    {
        // Constructor
        public ZoneGroupCollection()
        {

        }
        public ZoneGroup this[int index]
        {
            get { return (ZoneGroup)InnerList[index]; }
        }
        // Add
        public void Add(ZoneGroup zg)
        {
            InnerList.Add(zg);
        }
        // Remove
        public void Remove(ZoneGroup zg)
        {
            InnerList.Remove(zg);
        }
        // Get zg by it's zgID
        public ZoneGroup GetzgById(string zgId)
        {
            foreach (ZoneGroup zg in InnerList)
            {
                if (zg.Id == zgId)
                {
                    return zg;
                }
            }
            return null;
        }
    }
}
