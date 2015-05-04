using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.DatabaseServices;

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
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                //插入表示站点图形
                BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
                bool hasLeftSideMark = false;
                bool hasRightSideMark = false;
                //查找是已存在站点标识
                foreach (ObjectId blockRecordId in bt)
                {
                    BlockTableRecord btRecord = (BlockTableRecord)trans.GetObject(blockRecordId, OpenMode.ForRead);
                    if (btRecord.Name == "左侧站点标示")
                    {
                        hasLeftSideMark = true;
                        break;
                    }

                    if (btRecord.Name == "右侧站点标示")
                    {
                        hasRightSideMark = true;
                        break;
                    }
                }
                //如果不存在右侧标识则新建块
                if (hasRightSideMark == false)
                {

                }

                //如果不存在左侧标识则新建块
                if (hasLeftSideMark == false)
                {

                }
                Point3d insertP = new Point3d();
                DrawStationMark(db, trans, insertP, true);
                DrawStationMark(db, trans, insertP, false);
            }
            bool isSuc = false;
            string stationName = station_location.Name;
            string stationLocation = station_location.Location;

            //画表格

           
            
            
            //插入站名

            //插入站里程
            
            //插入站间距离


            return isSuc;
        }

        private void DrawStationMark(Database db, Transaction trans, Point3d insertPoint, bool isLeft)
        {
            

            //如果不存在则新建


        }

        private bool drawBlock(Point3d startDrawPoint, string BlockName)
        {
            bool isSuc = false;

            //
            return isSuc;
        }

        private bool drawLine(Point3d startDrawPoint, Point3d endDrawPoint)
        {
            bool isSuc = false;
            

            //
            return isSuc;
        }

        private bool drawText(Point3d startDrawPoint, string drawText)
        {
            bool isSuc = false;


            //
            return isSuc;
        }
    }
}
