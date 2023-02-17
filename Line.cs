using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3;
public class Line {
    #region Fields

    private (double x, double y) _point1;
    private (double x, double y) _point2;
    private double _length;

    #endregion

    #region Properties

    public (double x, double y) Point1 {
        get => _point1;
        set {
            var newLength = Math.Sqrt(
                Math.Pow(Point2.x - value.x, 2)
                + Math.Pow(Point2.y - value.y, 2)
            );
            if (Math.Abs(newLength - _length) > 0.0001f) {
                _point1 = value;
                _point2 = GetNewPoint(value, _point2);
            }
        }
    }
    public (double x, double y) Point2 {
        get => _point2;
        set {
            var newLength = Math.Sqrt(
                Math.Pow(value.x - Point1.x, 2)
                + Math.Pow(value.y - Point1.y, 2)
            );
            if (Math.Abs(newLength - _length) > 0.0001f) {
                _point1 = GetNewPoint(value, _point1);
                _point2 = value;
            }
        }
    }

    #endregion

    #region Constructors

    public Line((double x, double y) point1, (double x, double y) point2) {
        _point1 = point1;
        _point2 = point2;

        _length = Math.Sqrt(
            Math.Pow(Point2.x - Point1.x, 2)
            + Math.Pow(Point2.y - Point1.y, 2)
        );
    }

    public Line(double x1, double y1, double x2, double y2) : this((x1, y1), (x2, y2)) { }

    #endregion

    #region Private methods

    private (double x, double y) GetNewPoint((double x, double y) newPoint, (double x, double y) secondPoint) {
        
        var fi = Math.Atan(
            (newPoint.y - secondPoint.y) / (newPoint.x - secondPoint.x)
        );

        double x22 = _length * Math.Cos(fi) + newPoint.x;
        double y22 = _length * Math.Sin(fi) + newPoint.y;

        return (x22, y22);
    }

    #endregion

    #region Public methods
    
    public double CalcLength() {
        return Math.Sqrt(
            Math.Pow(this._point2.x - this._point1.x, 2)
            + Math.Pow(this._point2.y - this._point1.y, 2)
        );
    }

    public override string ToString() {
        return $"1:({Point1.x}; {Point1.y})\t2:({Point2.x}; {Point2.y})";
    }

    #endregion
}
