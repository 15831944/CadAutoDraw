using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Geometry;

namespace AutoDrawDWG
{
    class Draw_Station_Location
    {
        /*public class StationAndLocation
        {
            private string _stationName;
            private string _stationLocation;

            public string stationName
            {
                get { return _stationName; }
                set { _stationName = value; }
            }

            public string stationLocation
            {
                get { return _stationLocation; }
                set { _stationLocation = value; }
            }

            public StationAndLocation(string Name, string Location)
            {
                this.stationName = Name;
                this.stationLocation = Location;
            }
        }
        */
        public bool drawSL(Point3d startDrawPoint, Form1.StationAndLocation station_location, string BlockName)
        {
            bool isSuc = false;
            string stationName = station_location.Name;
            string stationLocation = station_location.Location;

            //画表格

            //插入块

            //插入站名

            //插入站里程
            
            //插入站间距离


            return isSuc;
        }

        public bool drawBlock(Point3d startDrawPoint, string BlockName)
        {
            bool isSuc = false;

            //
            return isSuc;
        }

        public bool drawLine(Point3d startDrawPoint, Point3d endDrawPoint)
        {
            bool isSuc = false;
            

            //
            return isSuc;
        }

        public bool drawText(Point3d startDrawPoint, string drawText)
        {
            bool isSuc = false;


            //
            return isSuc;
        }
    }
}
