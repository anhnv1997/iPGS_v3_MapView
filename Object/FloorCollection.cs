using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapView.Object
{
    public class FloorCollection : CollectionBase
    {

        // Constructor
        public FloorCollection()
        {

        }

        public Floor this[int index]
        {
            get { return (Floor)InnerList[index]; }
        }

        // Add
        public void Add(Floor zone)
        {
            {
                InnerList.Add(zone);
            }
        }

        // Remove
        public void Remove(Floor zone)
        {
            {
                InnerList.Remove(zone);
            }
        }

        // Get zone by it's zoneID
        public Floor GetFloor(string floorID)
        {
            {
                foreach (Floor floor in InnerList)
                {
                    if (floor.Id == floorID)
                    {
                        return floor;
                    }
                }
                return null;

            }
        }
    }
}
