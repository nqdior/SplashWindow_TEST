using System;
using System.Windows;
using System.Windows.Media;

namespace Reseacher
{
    public class CircleProgressBar
    {
        /// <summary>周角( 360°)</summary>
        private const double ROUND_ANGLE = 360d;
        /// <summary>平角( 180°)</summary>
        private const double STRAIGHT_ANGLE = 180d;
        /// <summary>直角( 90°)</summary>
        private const double RIGHT_ANGLE = 90d;
        /// <summary>端の値</summary>
        private const double END_OFFSET = 0.1;

        /// <summary>
        /// コントロールの描画設定
        /// </summary>
        /// <param name="element">設定するコントロール</param>
        /// <param name="value">0～100の数値</param>
        /// <param name="isFront">前景(true)/背景(false)</param>
        public static void SetValue(ref System.Windows.Shapes.Path element,
                                    double value, bool isFront)
        {
            double thick = element.StrokeThickness / 2d;
            double angle = CalcAngle(value);
            var fig = new PathFigure()
            {   // 開始点の設定
                StartPoint = new Point(element.Width / 2, thick)
            };

            double radius = (element.Width / 2) - thick;    // 半径
            var endPoint = CalcEndPoint(angle, radius);     // 終了点
            bool isLargeArcFlg = angle >= STRAIGHT_ANGLE;

            // 描画コントロールの作成
            var seg = new ArcSegment()
            {
                Point = new Point(endPoint.X + thick, endPoint.Y + thick),
                Size = new Size(radius, radius),
                // foregroundとbackgroundで設定変更
                IsLargeArc = isFront ? isLargeArcFlg : !isLargeArcFlg,
                SweepDirection = isFront ? SweepDirection.Clockwise
                                         : SweepDirection.Counterclockwise,
                RotationAngle = 0,
            };

            // コントロールの設定
            fig.Segments.Clear();
            fig.Segments.Add(seg);
            element.Data = new PathGeometry(new PathFigure[] { fig });
        }

        /// <summary>
        /// 0 ～ 100 の値を角度へ変換
        /// </summary>
        /// <param name="value"></param>
        private static double CalcAngle(double value)
        {
            double result = Math.Floor(value) * 3.6; // ROUND_ANGLE / 100
            if (result <= 0) { return END_OFFSET; }
            if (result >= 360) { return ROUND_ANGLE - END_OFFSET; }
            return result;
        }

        /// <summary>
        /// 終了点の座標計算
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="radius"></param>
        private static Point CalcEndPoint(double angle, double radius)
        {
            double radian = Math.PI * (angle - RIGHT_ANGLE) / 180;
            double x = radius + radius * Math.Cos(radian);
            double y = radius + radius * Math.Sin(radian);
            return new Point(x, y);
        }
    }
}
