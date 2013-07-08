using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ShapeDetectionEngine
{
    public class ShapeDetectionEngine
    {
        public string FolderName { get; set; }
        public Bitmap Picture { get; set; }
        public Bitmap Copy { get; set; }
        SimpleShapeChecker ShapeChecker { get; set; }
        BlobCounter ShapeAnalyser { get; set; }

        public ShapeDetectionEngine()
        {
            Picture = (Bitmap)Bitmap.FromFile(@"C:\Users\RLEI\Pictures\Products\prod.jpg");
            Copy = (Bitmap)Bitmap.FromFile(@"C:\Users\RLEI\Pictures\Products\prod.jpg");
            ShapeChecker = new SimpleShapeChecker();
            ShapeAnalyser = new BlobCounter();
            string date = DateTime.Now.Date.ToString("dMyyyy");
            FolderName = string.Format("Kuhlschrank-{0}", date);

            ShapeAnalyser.FilterBlobs = true;
            ShapeAnalyser.MinHeight = 200;
            ShapeAnalyser.MinWidth = 500;
            Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), FolderName));
        }

        public bool ProcessImage()
        {
            BitmapData bitData = Picture.LockBits(new Rectangle(0, 0, Picture.Width, Picture.Height), ImageLockMode.ReadWrite, Picture.PixelFormat);

            ColorFiltering filter = new ColorFiltering();

            filter.Red = new IntRange(0, 64);
            filter.Green = new IntRange(0, 64);
            filter.Blue = new IntRange(0, 64);
            filter.FillOutsideRange = false;

            filter.ApplyInPlace(bitData);

            ShapeAnalyser.ProcessImage(bitData);
            Blob[] blobs = ShapeAnalyser.GetObjectsInformation();
            Picture.UnlockBits(bitData);

            for (int i = 0; i < blobs.Length; i++)
            {
                List<IntPoint> edgePoints = ShapeAnalyser.GetBlobsEdgePoints(blobs[i]);
                List<IntPoint> corners;
                ShapeChecker.IsConvexPolygon(edgePoints, out corners);
                
                IntPoint pt0 = corners[0];
                IntPoint pt1 = corners[1];
                IntPoint pt2 = corners[2];

                double width = Math.Sqrt(Math.Pow(pt1.X - pt0.X, 2) + Math.Pow(pt1.Y - pt0.Y, 2));
                double height = Math.Sqrt(Math.Pow(pt2.X - pt1.X, 2) + Math.Pow(pt2.Y - pt1.Y, 2));

                Rectangle crop = new Rectangle(corners[0].X, corners[1].Y, (int)width + 50, (int)height + 50);
                Bitmap target = new Bitmap(crop.Width, crop.Height);
                using (Graphics gr = Graphics.FromImage(target))
                    gr.DrawImage(Copy, new Rectangle(0, 0, target.Width, target.Height), crop, GraphicsUnit.Pixel);

                target.Save(string.Format(@"{0}\{1}\crop{2}.jpg", Path.GetTempPath(), FolderName, i));
            }
            

            return false;
        }
    }
}
