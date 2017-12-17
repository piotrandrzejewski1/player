using System;
using UIKit;

namespace Player.iOS.Helpers
{
    public static class AppColors
    {
        public static UIColor Accent = UIColor.FromRGB((nfloat)(0.0 / 255.0), (nfloat)(195.0 / 255.0), (nfloat)(166.0 / 255.0));
        public static UIColor PageBackground = UIColor.FromRGB((nfloat)(10.0 / 255.0), (nfloat)(10.0 / 255.0), (nfloat)(10.0 / 255.0));
        public static UIColor GrayBackground = UIColor.FromRGB((nfloat)(40.0 / 255.0), (nfloat)(40.0 / 255.0), (nfloat)(40.0 / 255.0));
        public static UIColor White = UIColor.White;
        public static UIColor Transparent = UIColor.Clear;
    
        public static UIColor ChangeAlpha(this UIColor color, float alpha)
        {
            nfloat r,g,b,a;
            color.GetRGBA(out r, out g, out b, out a);
            return UIColor.FromRGBA(r, g, b, a * alpha);
        }

        public static UIColor Lighter(this UIColor color, float multiplaer)
        {
            nfloat r, g, b, a;
            color.GetRGBA(out r, out g, out b, out a);
            return UIColor.FromRGBA(r * multiplaer, g * multiplaer, b * multiplaer, a);
        }
    }
}
