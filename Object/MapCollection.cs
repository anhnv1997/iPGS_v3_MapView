using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Object
{
    public class MapCollection : CollectionBase
    {
        // Constructor
        public MapCollection()
        {

        }
        public Map this[int index]
        {
            get { return (Map)InnerList[index]; }
        }
        // Get zone by it's zoneID
        public Map GetMap(string mapID)
        {
            foreach (Map map in InnerList)
            {
                if (map.ID == mapID)
                {
                    return map;
                }
            }
            return null;
        }
        // Add
        public void Add(Map map)
        {
            InnerList.Add(map);
        }
        // Remove
        public void Remove(Map map)
        {
            InnerList.Remove(map);
        }
        
    }
}


