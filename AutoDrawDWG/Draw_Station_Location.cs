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

                    //用于生成图块， 如站点图块，铁路标识
                    if (CheckBlock(db, trans))
                    {
                        //在相应位置插入图块和实体
                        trans.Commit();
                    }
                    else
                    {
                        Application.ShowAlertDialog("Error");
                    }
                    //插入表示站点图形
                    
                    //Point3d insertP = new Point3d();
                    //DrawStationMark(db, trans, insertP, true);
                    //DrawStationMark(db, trans, insertP, false);

                    
                    m_DocumentLock.Dispose();
                }
                catch (Exception ee)
                {

                    Application.ShowAlertDialog("Message: " + ee.Message.ToString() + System.Environment.NewLine + "Source: " + ee.Source.ToString() + System.Environment.NewLine + "TargetSite: " + ee.TargetSite.ToString() + System.Environment.NewLine + "StackTrace: " + ee.StackTrace.ToString());
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

        #region 图块
        public bool CheckBlock(Database db, Transaction trans)
        {
            bool allCheck = false;

            BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, OpenMode.ForRead);
            bool hasLeftSideMark = false;
            bool hasRightSideMark = false;
            bool hasRailWayMark = false;
            //查找是已存在站点标识

            Point3d insertPoint = new Point3d();
            //如果不存在右侧标识则新建块
            if (!bt.Has("到达站站点标示"))
            {
                Form1.StationAndLocation station_location = new Form1.StationAndLocation("1", "吉林站", "DK0+000");
                CreateStationMark(db, trans, insertPoint, false, station_location);
            }

            //如果不存在左侧标识则新建块
            //Point3d insertPoint2 = new Point3d(insertPoint.X + 100, insertPoint.Y, insertPoint.Z);
            if (!bt.Has("始发站站点标示"))
            {
                Form1.StationAndLocation station_location = new Form1.StationAndLocation("1", "蛟河西站", "DK66+535");
                CreateStationMark(db, trans, insertPoint, true, station_location);
            }

            //如果不存在铁轨标识则新建块
            if (!bt.Has("铁轨_Length_248"))
            {
                CreateRailWayMark(db, trans, insertPoint, "XX上行线/下行线");
            }

            allCheck = true;
            return allCheck;
        }
        //添加铁轨标识
        private void CreateRailWayMark(Database db, Transaction trans, Point3d insertPoint, string RailWayDirection)
        {
            // Open the Block table for read
            BlockTable acBlkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write
            BlockTableRecord acBlkTblRec = new BlockTableRecord();
            acBlkTbl.UpgradeOpen();
            acBlkTbl.Add(acBlkTblRec);
            acBlkTblRec.Name = "铁轨_Length_248";

            //块属性
            double textHeight = 5;
            AttributeDefinition ProjectNameShortAtt = new AttributeDefinition(new Point3d(insertPoint.X, insertPoint.Y - textHeight, 0), RailWayDirection, "上/下行", "输入线路名简称", ObjectId.Null);
            SetStyleForAtt(ProjectNameShortAtt, textHeight, false);

            acBlkTblRec.AppendEntity(ProjectNameShortAtt);
            trans.AddNewlyCreatedDBObject(ProjectNameShortAtt, true);
            //ProjectNameShortAtt.AlignmentPoint = new Point3d(1, 1, 0);

            Polyline BigRectangle = new Polyline(4);
            BigRectangle.AddVertexAt(0, new Point2d(insertPoint.X + 40, insertPoint.Y), 0, 0.1, 0.1);
            BigRectangle.AddVertexAt(1, new Point2d(insertPoint.X + 40 + 248, insertPoint.Y), 0, 0.1, 0.1);
            BigRectangle.AddVertexAt(2, new Point2d(insertPoint.X + 40 + 248, insertPoint.Y - 7), 0, 0.1, 0.1);
            BigRectangle.AddVertexAt(3, new Point2d(insertPoint.X + 40, insertPoint.Y - 7), 0, 0.1, 0.1);
            BigRectangle.Closed = true;
            acBlkTblRec.AppendEntity(BigRectangle);
            trans.AddNewlyCreatedDBObject(BigRectangle, true);

            Polyline InsideRectangle_1 = new Polyline(4);
            InsideRectangle_1.AddVertexAt(0, new Point2d(insertPoint.X + 90, insertPoint.Y), 0, 0.1, 0.1);
            InsideRectangle_1.AddVertexAt(1, new Point2d(insertPoint.X + 140, insertPoint.Y), 0, 0.1, 0.1);
            InsideRectangle_1.AddVertexAt(2, new Point2d(insertPoint.X + 140, insertPoint.Y - 7), 0, 0.1, 0.1);
            InsideRectangle_1.AddVertexAt(3, new Point2d(insertPoint.X + 90, insertPoint.Y - 7), 0, 0.1, 0.1);
            InsideRectangle_1.Closed = true;
            acBlkTblRec.AppendEntity(InsideRectangle_1);
            trans.AddNewlyCreatedDBObject(InsideRectangle_1, true);

            Polyline InsideRectangle_2 = new Polyline(4);
            InsideRectangle_2.AddVertexAt(0, new Point2d(insertPoint.X + 190, insertPoint.Y), 0, 0.1, 0.1);
            InsideRectangle_2.AddVertexAt(1, new Point2d(insertPoint.X + 240, insertPoint.Y), 0, 0.1, 0.1);
            InsideRectangle_2.AddVertexAt(2, new Point2d(insertPoint.X + 240, insertPoint.Y - 7), 0, 0.1, 0.1);
            InsideRectangle_2.AddVertexAt(3, new Point2d(insertPoint.X + 190, insertPoint.Y - 7), 0, 0.1, 0.1);
            InsideRectangle_2.Closed = true;
            acBlkTblRec.AppendEntity(InsideRectangle_2);
            trans.AddNewlyCreatedDBObject(InsideRectangle_2, true);

            Hatch hatch = new Hatch();
            acBlkTblRec.AppendEntity(hatch);
            trans.AddNewlyCreatedDBObject(hatch, true);

            hatch.SetDatabaseDefaults();
            hatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
            hatch.Associative = true;
            ObjectIdCollection ids = new ObjectIdCollection();
            ids.Add(InsideRectangle_1.ObjectId);

            ObjectIdCollection ids1 = new ObjectIdCollection();
            ids1.Add(InsideRectangle_2.ObjectId);

            hatch.AppendLoop(HatchLoopTypes.Default, ids);

            hatch.AppendLoop(HatchLoopTypes.Default, ids1);

            hatch.EvaluateHatch(true);
            db.TransactionManager.AddNewlyCreatedDBObject(acBlkTblRec, true);
            //acBlkTblRec.ObjectId.AddAttsToBlock(ProjectNameShortAtt);

            //Dictionary<string,string> att=new Dictionary<string,string>();
            //att.Add("xx上行线/下行线","吉珲上行线");
            //double textHeight=50;
            //db.CurrentSpaceId.InsertBlockReference("0", "铁轨_Length_248", new Point3d(insertPoint.X, insertPoint.Y - textHeight / 2, 0), new Scale3d(2), 0, att);
            acBlkTbl.DowngradeOpen();
        }

        private void SetStyleForAtt(AttributeDefinition att, bool invisible)
        {
            att.Height = 0.15;//高度
            att.HorizontalMode = TextHorizontalMode.TextCenter;
            att.VerticalMode = TextVerticalMode.TextVerticalMid;
            att.Invisible = invisible;
        }

        private void SetStyleForAtt(AttributeDefinition att, double textHeight, bool invisible)
        {
            att.Height = textHeight;//高度
            att.HorizontalMode = TextHorizontalMode.TextCenter;
            att.VerticalMode = TextVerticalMode.TextVerticalMid;
            att.Invisible = invisible;
        }
        //新建站点标识
        private void CreateStationMark(Database db, Transaction trans, Point3d insertPoint, bool isLeft, Form1.StationAndLocation station_location)
        {
            // Open the Block table for read
            BlockTable acBlkTbl;

            acBlkTbl = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

            // Open the Block table record Model space for write

            BlockTableRecord acBlkTblRec = new BlockTableRecord();
            acBlkTbl.UpgradeOpen();
            acBlkTbl.Add(acBlkTblRec);
            if (isLeft == false)
            {
                acBlkTblRec.Name = "到达站站点标示";
            }
            else
            {
                acBlkTblRec.Name = "始发站站点标示";
            }
            //acBlkTblRec = trans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;


            Point2d CircleCenter = new Point2d(insertPoint.X, insertPoint.Y);

            //画圆（左右两个半圆）
                //起始、终止角度
            double startAngle = 90;
            double endAngle = 270;
                //内圆 由两个arc组成
                    //左侧
            Arc InnerArcLeft = new Arc(new Point3d(CircleCenter.X, CircleCenter.Y, 0), 2, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            acBlkTblRec.AppendEntity(InnerArcLeft);
            trans.AddNewlyCreatedDBObject(InnerArcLeft, true);

                    //右侧
            Arc InnerArcRight = new Arc(new Point3d(CircleCenter.X, CircleCenter.Y, 0), 2, endAngle.DegreeToRadian(), startAngle.DegreeToRadian());
            acBlkTblRec.AppendEntity(InnerArcRight);
            trans.AddNewlyCreatedDBObject(InnerArcRight, true);

                //外圆 由两个arc组成
                    //左侧
            Arc OuterArcLeft = new Arc(new Point3d(CircleCenter.X, CircleCenter.Y, 0), 4, startAngle.DegreeToRadian(), endAngle.DegreeToRadian());
            acBlkTblRec.AppendEntity(OuterArcLeft);
            trans.AddNewlyCreatedDBObject(OuterArcLeft, true);

                    //右侧
            Arc OuterArcRight = new Arc(new Point3d(CircleCenter.X, CircleCenter.Y, 0), 4, endAngle.DegreeToRadian(), startAngle.DegreeToRadian());
            acBlkTblRec.AppendEntity(OuterArcRight);
            trans.AddNewlyCreatedDBObject(OuterArcRight, true);

            //直线
            Polyline pline = new Polyline();
            pline.CreatePolyline(new Point2d(CircleCenter.X, CircleCenter.Y + 4), new Point2d(CircleCenter.X, CircleCenter.Y - 36));
            acBlkTblRec.AppendEntity(pline);
            trans.AddNewlyCreatedDBObject(pline, true);

            //内辅助直线
            Polyline innerPline = new Polyline();
            innerPline.CreatePolyline(new Point2d(CircleCenter.X, CircleCenter.Y + 2), new Point2d(CircleCenter.X, CircleCenter.Y - 2));
            acBlkTblRec.AppendEntity(innerPline);
            trans.AddNewlyCreatedDBObject(innerPline, true);

            //外辅助直线
            Polyline outerPline = new Polyline();
            outerPline.CreatePolyline(new Point2d(CircleCenter.X, CircleCenter.Y + 4), new Point2d(CircleCenter.X, CircleCenter.Y - 4));
            acBlkTblRec.AppendEntity(outerPline);
            trans.AddNewlyCreatedDBObject(outerPline, true);

            //添加两个属性块： 站名，里程
            double textHeight = 3;
            AttributeDefinition AttStationName = new AttributeDefinition();            

            //设置两个属性块对齐方式，对齐点
            AttStationName.TextString = "XXX站";
            AttStationName.Tag = "站名";
            AttStationName.Prompt = "输入站点名称"; 
            SetStyleForAtt(AttStationName, textHeight, false);
            AttStationName.TextStyleId = ObjectId.Null;
            AttStationName.Justify = AttachmentPoint.BaseCenter;

            //AttStationName.HorizontalMode = TextHorizontalMode.TextCenter; //水平方向取中点
            //AttStationName.VerticalMode = TextVerticalMode.TextVerticalMid;
            AttStationName.AlignmentPoint = new Point3d(insertPoint.X, insertPoint.Y + 6, 0);
            //AdjustAlignment(db);
            //AttStationName.AdjustAlignment(db);
            /*
            AttStationName.HorizontalMode = TextHorizontalMode.TextCenter; //水平方向取中点
            AttStationName.VerticalMode = TextVerticalMode.TextVerticalMid;
            AttStationName.AlignmentPoint = new Point3d(insertPoint.X, insertPoint.Y + 6, 0);
             */

            AttributeDefinition AttStationLocation = new AttributeDefinition();
            //new Point3d(insertPoint.X, insertPoint.Y - 18, 0), "", "里程", "输入站点里程", ObjectId.Null);
            
            AttStationLocation.TextString = "XXX站";
            AttStationLocation.Tag = "里程";
            AttStationLocation.Prompt = "输入站点里程";
            AttStationLocation.TextStyleId = ObjectId.Null;
            AttStationLocation.Justify = AttachmentPoint.TopCenter;
            //double rotatedAngle = 90;
            //AttStationLocation.Rotation = rotatedAngle.DegreeToRadian();
            AttStationLocation.AlignmentPoint = new Point3d(insertPoint.X + 1, insertPoint.Y - 18, 0);
            /*
            AttStationLocation.HorizontalMode = TextHorizontalMode.TextCenter; //水平方向取终点
            AttStationLocation.VerticalMode = TextVerticalMode.TextBottom;
            AttStationLocation.AlignmentPoint = new Point3d(insertPoint.X + 1, insertPoint.Y - 18, 0);
            
            */
            //AttStationLocation.HorizontalMode = TextHorizontalMode.TextCenter; //水平方向取终点
            //AttStationLocation.VerticalMode = TextVerticalMode.TextTop;
            //AttStationLocation.AlignmentPoint = new Point3d(insertPoint.X + 3, insertPoint.Y - 18, 0);
            //AttStationLocation.AdjustAlignment(db);
            
            //AttStationLocation.HorizontalMode = TextHorizontalMode.TextCenter; //水平方向取终点
            //AttStationLocation.VerticalMode = TextVerticalMode.TextBottom;
            //AttStationLocation.AlignmentPoint = new Point3d(insertPoint.X + 1, insertPoint.Y - 18, 0);
             
            
            //设置属性块高度和可见性
            
            //SetStyleForAtt(AttStationLocation, textHeight, false);

            //添加到块定义中
            acBlkTblRec.AppendEntity(AttStationName);
            trans.AddNewlyCreatedDBObject(AttStationName, true);
            acBlkTblRec.AppendEntity(AttStationLocation);
            trans.AddNewlyCreatedDBObject(AttStationLocation, true);

            if (isLeft == false)
            {
                ObjectIdCollection ids = new ObjectIdCollection();
                ids.Add(OuterArcLeft.ObjectId);
                ids.Add(outerPline.ObjectId);

                ObjectIdCollection ids2 = new ObjectIdCollection();
                ids2.Add(InnerArcLeft.ObjectId);
                ids2.Add(innerPline.ObjectId);

                Hatch hatch = new Hatch();
                acBlkTblRec.AppendEntity(hatch);

                trans.AddNewlyCreatedDBObject(hatch, true);

                hatch.SetDatabaseDefaults();

                hatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");

                hatch.Associative = true;

                hatch.AppendLoop(HatchLoopTypes.Outermost, ids);

                hatch.AppendLoop(HatchLoopTypes.Default, ids2);

                hatch.EvaluateHatch(true);

                ids.Clear();
                ids2.Clear();

            }
            else
            {
                ObjectIdCollection ids = new ObjectIdCollection();
                ids.Add(OuterArcRight.ObjectId);
                ids.Add(outerPline.ObjectId);

                ObjectIdCollection ids2 = new ObjectIdCollection();
                ids2.Add(InnerArcRight.ObjectId);
                ids2.Add(innerPline.ObjectId);

                Hatch hatch = new Hatch();

                acBlkTblRec.AppendEntity(hatch);

                trans.AddNewlyCreatedDBObject(hatch, true);

                hatch.SetDatabaseDefaults();

                hatch.SetHatchPattern(HatchPatternType.PreDefined, "SOLID");
                //hatch.CreateHatch(HatchPatternType.PreDefined, "SOLID", true);
                hatch.Associative = true;

                hatch.AppendLoop(HatchLoopTypes.Outermost, ids);

                hatch.AppendLoop(HatchLoopTypes.Default, ids2);

                hatch.EvaluateHatch(true);

                ids.Clear();
                ids2.Clear();

            }
            //acBlkTbl.Add(acBlkTblRec);
            db.TransactionManager.AddNewlyCreatedDBObject(acBlkTblRec, true);
            acBlkTbl.DowngradeOpen();

        }

        #endregion 

        #region 绘图
        public void drawTable(Database db, Transaction trans, Point3d insertPoint)
        {

        }
        #endregion

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
