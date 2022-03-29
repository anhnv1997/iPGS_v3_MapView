using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MapView
{
    public class MapDetailCollection : CollectionBase
    {
        // Constructor
        public MapDetailCollection()
        {

        }
        public MapDetail this[int index]
        {
            get { return (MapDetail)InnerList[index]; }
        }
        // Get MapDetail by it's mapID and zoneId
        public MapDetail GetMapDetail(string mapId, string zoneId)
        {
            foreach (MapDetail mapDetail in InnerList)
            {
                if (mapDetail.MapId == mapId && mapDetail.ZONEId == zoneId)
                {
                    return mapDetail;
                }
            }
            return null;
        }
        public MapDetail GetMapDetail(string mapId)
        {
            foreach (MapDetail mapDetail in InnerList)
            {
                if (mapDetail.MapId == mapId)
                {
                    return mapDetail;
                }
            }
            return null;
        }
        // Add
        public void Add(MapDetail mapDetail)
        {
            InnerList.Add(mapDetail);
        }
        // Remove
        public void Remove(MapDetail mapDetail)
        {
            InnerList.Remove(mapDetail);
        }
        public void RemoveByZoneID(string zoneID)
        {
            List<MapDetail> deleteMapList = new List<MapDetail>();
            foreach (MapDetail mapDetail in InnerList)
            {
                if (mapDetail.ZONEId == zoneID)
                {
                    deleteMapList.Add(mapDetail);
                }
            }
            foreach (MapDetail mapDetail in deleteMapList)
            {
                InnerList.Remove(mapDetail);
            }
        }
        public void RemoveByMapID(string mapID)
        {
            List<MapDetail> deleteMapList = new List<MapDetail>();
            foreach (MapDetail mapDetail in InnerList)
            {
                if (mapDetail.MapId == mapID)
                {
                    deleteMapList.Add(mapDetail);
                }
            }
            foreach (MapDetail mapDetail in deleteMapList)
            {
                InnerList.Remove(mapDetail);
            }
        }
        
    }
}
