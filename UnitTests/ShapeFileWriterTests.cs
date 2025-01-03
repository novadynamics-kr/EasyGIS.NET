using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EGIS.ShapeFileLib;
using EGIS.Projections;

namespace UnitTests
{
	[TestFixture]
	internal class ShapeFileWriterTests
	{
		[Test]
		public void CreateMultiPointShapeFile()
		{
			string outputDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetRandomFileName());

			if (!System.IO.Directory.Exists(outputDir))
			{
				System.IO.Directory.CreateDirectory(outputDir);
			}
			string shapeFileName = "multipoint";

			//create the dbf field descriptions. We'll just create a single attribute to store 
			//record number
			DbfFieldDesc[] attributes = new DbfFieldDesc[1];
			attributes[0].FieldName = "RecNum";
			attributes[0].FieldType = DbfFieldType.Number;
			attributes[0].FieldLength = 6;
			attributes[0].DecimalCount = 0;

			//create wkt for wgs84 projection
			ICRS wgs84Crs = EGIS.Projections.CoordinateReferenceSystemFactory.Default.GetCRSById(CoordinateReferenceSystemFactory.Wgs84EpsgCode);
			string projWkt = wgs84Crs.GetWKT(PJ_WKT_TYPE.PJ_WKT1_GDAL,false);

			try
			{
				using (ShapeFileWriter writer = ShapeFileWriter.CreateWriter(outputDir, shapeFileName, ShapeType.MultiPoint, attributes, projWkt))
				{
					string[] attributeValues = new string[1];
					PointD[] pts = new PointD[5];

					//add the first record with a single point
					pts[0] = new PointD(145, -37);
					attributeValues[0] = "1";
					writer.AddRecord(pts, 1, attributeValues);

					//add next record with 3 points
					pts[0] = new PointD(146, -37);
					pts[1] = new PointD(146.5, -37);
					pts[2] = new PointD(147, -36);
					attributeValues[0] = "2";
					writer.AddRecord(pts, 3, attributeValues);

					//add next record with 4 points
					pts[0] = new PointD(145, -38);
					pts[1] = new PointD(145, -38.5);
					pts[2] = new PointD(145, -38.6);
					pts[3] = new PointD(145, -38.7);

					attributeValues[0] = "3";
					writer.AddRecord(pts, 4, attributeValues);
										
				}

				using (ShapeFile sf = new ShapeFile(System.IO.Path.Combine(outputDir, shapeFileName)))
				{
					Assert.That(sf.RecordCount == 3, Is.True, "Multipoint shapefile should contain 3 records");

					//read the 3rd record
					var geometry = sf.GetShapeDataD(2);

					Assert.That(geometry[0].Length == 4, Is.True, "4th record should contain 4 points");

					Assert.That(geometry[0][3].X, Is.EqualTo(145).Within(0.0000001), "last point of record 4 has unexpected x coordinate");
					Assert.That(geometry[0][3].Y, Is.EqualTo(-38.7).Within(0.0000001), "last point of record 4 has unexpected y coordinate");


					var shapeFileExtent = sf.Extent;

					//note that the RectangleD Top and Bottom are swapped as the RectangleD was originally derived using screen coordinates
					RectangleD expectedExtent = RectangleD.FromLTRB(145, -38.7, 147, -36);

					Assert.That(shapeFileExtent.Left, Is.EqualTo(expectedExtent.Left).Within(0.0000001), $"extent Xmin value should be :{expectedExtent.Left}");
                    Assert.That(shapeFileExtent.Left, Is.EqualTo(expectedExtent.Left).Within(0.0000001), $"extent Xmin value should be :{expectedExtent.Left}");
					Assert.That(shapeFileExtent.Right, Is.EqualTo(expectedExtent.Right).Within(0.0000001), $"extent Xmax value should be :{expectedExtent.Right}");
					Assert.That(shapeFileExtent.Top, Is.EqualTo(expectedExtent.Top).Within(0.0000001), $"extent Ymin value should be :{expectedExtent.Top}");
					Assert.That(shapeFileExtent.Bottom, Is.EqualTo(expectedExtent.Bottom).Within(0.0000001), $"extent Ymax value should be :{expectedExtent.Bottom}");

					Assert.That(sf.CoordinateReferenceSystem.IsEquivalent(wgs84Crs), Is.True, "shapefile CRS should be wgs84");
				}

			}
			finally
			{				
				System.IO.Directory.Delete(outputDir,true);				
			}

		}
	}
}
