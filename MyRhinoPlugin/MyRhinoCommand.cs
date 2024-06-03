using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Rhino;
using Rhino.DocObjects;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input.Custom;

namespace MyRhinoPlugin
{
 public class MyRhinoCommand : Command
    {
        public MyRhinoCommand()
        {
            Instance = this;
        }

        public static MyRhinoCommand Instance { get; private set; }

        public override string EnglishName => "MyRhinoCommand";

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            Form1 form = new Form1();
            form.ShowDialog();

            return Result.Success;
        }

        public static void CreateBox(RhinoDoc doc, List<Guid> boxIds, ref int boxCount)
        {
            double boxWidth = 92;
            double boxLength = 1200;
            double boxHeight = 2400;
            double spacing = 2000;

            // Calculate the location for the new box
            double x = boxCount * (boxWidth + spacing);
            Point3d basePoint = new Point3d(x, 0, 0);

            // Create the box geometry
            Box box = new Box(Plane.WorldXY, new Interval(0, boxWidth), new Interval(0, boxLength), new Interval(0, boxHeight));
            Brep boxBrep = box.ToBrep();

            // Create a block definition if it doesn't exist
            string blockName = "MyBoxBlock";
            if (doc.InstanceDefinitions.Find(blockName) == null)
            {
                var objects = new List<GeometryBase> { boxBrep };
                var attributes = new List<ObjectAttributes> { new ObjectAttributes { Name = blockName } };
                doc.InstanceDefinitions.Add(blockName, "Box Block Definition", basePoint, objects, attributes);
            }

            // Insert the block instance
            int blockIndex = doc.InstanceDefinitions.Find(blockName).Index;
            Transform transform = Transform.Translation(new Vector3d(basePoint));
            Guid blockInstanceId = doc.Objects.AddInstanceObject(blockIndex, transform);

            if (blockInstanceId != Guid.Empty)
            {
                boxIds.Add(blockInstanceId);
                boxCount++;
                doc.Views.Redraw();
            }
        }

        public static void DeleteLastBox(RhinoDoc doc, List<Guid> boxIds, ref int boxCount)
        {
            if (boxIds.Count > 0)
            {
                Guid lastBoxId = boxIds[boxIds.Count - 1];
                doc.Objects.Delete(lastBoxId, true);
                boxIds.RemoveAt(boxIds.Count - 1);
                boxCount--;
                doc.Views.Redraw();
            }
        }

        public static void DeleteAllBoxes(RhinoDoc doc, List<Guid> boxIds, ref int boxCount)
        {
            foreach (var id in boxIds)
            {
                doc.Objects.Delete(id, true);
            }
            boxIds.Clear();
            boxCount = 0;
            doc.Views.Redraw();
        }

        public static int GetBoxCount(List<Guid> boxIds)
        {
            return boxIds.Count;
        }
    }
}