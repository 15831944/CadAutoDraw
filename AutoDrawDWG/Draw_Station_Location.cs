using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DotNetARX;
using Autodesk.AutoCAD.ApplicationServices;
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
        public bool drawSL(Form1.StationAndLocation station_location)//Point3d startDrawPoint, , string BlockName)
        {
            Database db = HostApplicationServices.WorkingDatabase;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    DocumentLock m_DocumentLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument();

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
                    Point3d insertPoint = new Point3d();
                    //如果不存在右侧标识则新建块
                    if (hasRightSideMark == false)
                    {
                        CreateStationMark(db, trans, insertPoint, false);
                    }

                    //如果不存在左侧标识则新建块
                    Point3d insertPoint2 = new Point3d(insertPoint.X + 100, insertPoint.Y, insertPoint.Z);
                    if (hasLeftSideMark == false)
                    {
                        CreateStationMark(db, trans, insertPoint2, true);
                    }
                    Point3d insertP = new Point3d();
                    DrawStationMark(db, trans, insertP, true);
                    DrawStationMark(db, trans, insertP, false);

                    trans.Commit();
                    m_DocumentLock.Dispose();
                }
                catch (Exception ee)
                {

                    Application.ShowAlertDialog(ee.Message.ToString() + System.Environment.NewLine + ee.Source.ToString() + System.Environment.NewLine + ee.TargetSite.ToString());
                }
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

        //新建站点标识
        private void CreateStationMark(Database db, Transaction trans, Point3d insertPoint, bool isLeft)
        {
            Point2d CircleCenter = new Point2d(insertPoint.X, insertPoint.Y);

            //起始、终止角度
            double startAngle = 90;
            double endAngle = 270;
            //内圆 由两个arc组成
            //左侧
            Polyline InnerArcLeft = new Polyline();
            InnerArcLeft.CreatePolyArc(CircleCenter, 4, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            ObjectId InnerArcLeftID = db.AddToModelSpace(InnerArcLeft);

            //右侧
            Polyline InnerArcRight = new Polyline();
            InnerArcRight.CreatePolyArc(CircleCenter, 4, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            ObjectId InnerArcRightID = db.AddToModelSpace(InnerArcRight);

            //外圆 由两个arc组成
            //左侧
            Polyline OuterArcLeft = new Polyline();
            OuterArcLeft.CreatePolyArc(CircleCenter, 8, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            ObjectId OuterArcLeftID = db.AddToModelSpace(OuterArcLeft);

            //右侧
            Polyline OuterArcRight = new Polyline();
            OuterArcRight.CreatePolyArc(CircleCenter, 8, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            ObjectId OuterArcRightID = db.AddToModelSpace(OuterArcRight);

            //直线
            Polyline pline = new Polyline();
            pline.CreatePolyline(new Point2d(CircleCenter.X, CircleCenter.Y + 8), new Point2d(CircleCenter.X, CircleCenter.Y - 36));
            ObjectId plineID = db.AddToModelSpace(pline);

            ObjectIdCollection ids = new ObjectIdCollection();
            ids.Add(OuterArcLeftID);
            //ids.Add(OuterCircleID);
            ids.Add(plineID);

            ObjectIdCollection ids2 = new ObjectIdCollection();
            ids2.Add(InnerArcLeftID);
            //ids.Add(OuterCircleID);
            ids2.Add(plineID);

            ObjectIdCollection[] loops = new ObjectIdCollection[2];
            loops.SetValue(ids, 0);
            loops.SetValue(ids2, 1);

            Hatch hatch = new Hatch();
            hatch.PatternScale = 1;
            ObjectId hatEntId = AddHatch(out hatch, 0, "SOLID", Math.PI / 3, 10);
            //hatch.CreateHatch(HatchPatternType.PreDefined, "SOLID", true);

            hatch = (Hatch)trans.GetObject(hatEntId, OpenMode.ForWrite);
            //hatch.Associative = true;
            for (int i = 0; i < loops.Length; i++)
            {
                hatch.AppendLoop(HatchLoopTypes.Default, loops[i]);
            }

            //ObjectIdCollection ids2 = new ObjectIdCollection();
            //ids2.Add(InnerCircleID);

            //ObjectIdCollection[] loops = new ObjectIdCollection[2];
            //loops.SetValue(ids, 0);
            //loops.SetValue(ids2, 1);
            

            
            /*for (int i = 0; i < loops.Length; i++)
            {
                hatch.AppendLoop(HatchLoopTypes.Default, loops[i]);
            }*/

            /*if (isLeft == true)
            {
                ObjectIdCollection ids = new ObjectIdCollection();
                ids.Add(InnerArcLeftID);
                ObjectIdCollection ids2 = new ObjectIdCollection();
                ids2.Add(OuterArcLeftID);
                ObjectIdCollection ids3 = new ObjectIdCollection();
                ids.Add(plineID);

                ObjectIdCollection[] loops = new ObjectIdCollection[1];
                loops.SetValue(ids, 0);
                //loops.SetValue(ids2, 1);
                //loops.SetValue(ids3, 1);

                Hatch hatch = new Hatch();
                hatch.PatternScale = 1;
                hatch.CreateHatch(HatchPatternType.PreDefined, "SOLID", true);
                //图形填充
                hatch.Associative = true;
                for (int i = 0; i < loops.Length; i++)
                {
                    hatch.AppendLoop(HatchLoopTypes.Default, loops[i]);
                }
                ids.Clear();
                //hatch.EvaluateHatch(true);
                
            }
            else
            {
                ObjectIdCollection ids = new ObjectIdCollection();
                ids.Add(InnerArcRightID);
                ObjectIdCollection ids2 = new ObjectIdCollection();
                ids2.Add(OuterArcRightID);
                ObjectIdCollection ids3 = new ObjectIdCollection();
                ids.Add(plineID);

                ObjectIdCollection[] loops = new ObjectIdCollection[1];
                loops.SetValue(ids, 0);
                //loops.SetValue(ids2, 1);
                //loops.SetValue(ids3, 1);

                Hatch hatch = new Hatch();
                hatch.PatternScale = 1;
                hatch.CreateHatch(HatchPatternType.PreDefined, "SOLID", true);
                //图形填充
                hatch.Associative = true;

                for (int i = 0; i < loops.Length; i++)
                {
                    hatch.AppendLoop(HatchLoopTypes.Default, loops[i]);
                }
                ids.Clear();
                //hatch.EvaluateHatch(true);
            }*/
            
           


        }



        // 由图案填充类型、填充图案名称、
        // 填充角度和填充比例创建图案填充的函数.
        // partType:0为预定义图案；1为用户定义图案；2为自定义图案.
        private ObjectId AddHatch(out Hatch hatchEnt, HatchPatternType patType,
            String patName, Double patternAngle, Double patternScale)
        {
            Hatch ent = new Hatch();
            ent.HatchObjectType = HatchObjectType.HatchObject;
            Database db = HostApplicationServices.WorkingDatabase;

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject
                    (db.BlockTableId, OpenMode.ForRead);
                BlockTableRecord btr = (BlockTableRecord)trans.GetObject
                    (bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                ObjectId entId = btr.AppendEntity(ent);
                trans.AddNewlyCreatedDBObject(ent, true);
                ent.SetDatabaseDefaults();
                ent.PatternAngle = patternAngle;
                ent.PatternScale = patternScale;
                ent.SetHatchPattern(patType, patName);
                hatchEnt = ent;
                trans.Commit();
                return entId;
            }
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
