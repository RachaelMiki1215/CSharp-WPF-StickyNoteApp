using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFStickyNoteApp
{
    public sealed class RBPieGeometry : Shape
    {
        public static readonly DependencyProperty SizeProperty
            = DependencyProperty.Register("Size", typeof(Double), typeof(RBPieGeometry));
        public static readonly DependencyProperty PieAngleProperty
            = DependencyProperty.Register("PieAngle", typeof(Double), typeof(RBPieGeometry));
        public static readonly DependencyProperty RotationAngleProperty
            = DependencyProperty.Register("RotationAngle", typeof(Double), typeof(RBPieGeometry));

        public Double Size
        {
            get { return (Double)this.GetValue(SizeProperty); }
            set { this.SetValue(SizeProperty, value); }
        }
        public Double PieAngle
        {
            get { return (Double)this.GetValue(PieAngleProperty); }
            set { this.SetValue(PieAngleProperty, value); }
        }
        public Double RotationAngle
        {
            get { return (Double)this.GetValue(RotationAngleProperty); }
            set { this.SetValue(RotationAngleProperty, value); }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                Double radPieAngle = PieAngle * Math.PI / 180;

                EllipseGeometry ellipseGeo = new EllipseGeometry(new Point(Size/2, Size/2),
                    Size/2, Size/2);

                PathGeometry pathGeo = new PathGeometry();
                CombinedGeometry combinedGeo = new CombinedGeometry();
                if (PieAngle < 90)
                {
                    PathFigure path = new PathFigure();
                    path.IsClosed = true;
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, 0), true));
                    path.Segments.Add(new LineSegment(
                        new Point((Size / 2) + ((double)Math.Tan(radPieAngle) * (double)(Size / 2)), 0), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    pathGeo.Figures.Add(path);
                    
                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Intersect, ellipseGeo, pathGeo);
                }
                else if (PieAngle == 90)
                {
                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Intersect, ellipseGeo,
                        new RectangleGeometry(new Rect(Size / 2, 0, Size / 2, Size / 2)));
                }
                else if (PieAngle < 180)
                {
                    PathFigure path = new PathFigure();
                    path.IsClosed = true;
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, 0), true));
                    path.Segments.Add(new LineSegment(new Point(Size, 0), true));
                    path.Segments.Add(new LineSegment(
                        new Point(Size, (Size / 2) + ((double)Math.Tan(radPieAngle 
                        - (Math.PI / 2)) * (double)(Size/2))), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    pathGeo.Figures.Add(path);

                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Intersect, ellipseGeo, pathGeo);
                }
                else if (PieAngle == 180)
                {
                    pathGeo.AddGeometry(new RectangleGeometry(new Rect(Size/2, 0, Size / 2, Size)));
                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Intersect, ellipseGeo, pathGeo);
                }
                else if (PieAngle < 270)
                {
                    PathFigure path = new PathFigure();
                    path.IsClosed = true;
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, 0), true));
                    path.Segments.Add(new LineSegment(new Point(0, 0), true));
                    path.Segments.Add(new LineSegment(
                        new Point(0, (Size / 2) + ((double)Math.Tan((3/2*Math.PI) - radPieAngle) * 
                        (double)(Size / 2))), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    pathGeo.Figures.Add(path);

                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Exclude, ellipseGeo, pathGeo);
                }
                else if (PieAngle == 270)
                {
                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Exclude, ellipseGeo,
                        new RectangleGeometry(new Rect(0, 0, Size / 2, Size / 2)));
                }
                else if (PieAngle < 360)
                {
                    PathFigure path = new PathFigure();
                    path.IsClosed = true;
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, 0), true));
                    path.Segments.Add(new LineSegment(
                        new Point((Size / 2) + ((double)Math.Tan(2*Math.PI - radPieAngle) 
                        * (double)(Size / 2)), 0), true));
                    path.Segments.Add(new LineSegment(new Point(Size / 2, Size / 2), true));
                    pathGeo.Figures.Add(path);

                    combinedGeo = new CombinedGeometry(GeometryCombineMode.Exclude, ellipseGeo, pathGeo);
                }

                combinedGeo.Transform = new RotateTransform(RotationAngle, Size/2, Size/2);

                return combinedGeo;
            }
        }
    }
}
