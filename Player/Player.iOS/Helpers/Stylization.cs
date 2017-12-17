using System;
using System.Drawing;
using UIKit;

namespace Player.iOS.Helpers
{
    public static class Stylization
    {
        public static void StyleStandardButton(this UIButton button)
        {
            button.ClipsToBounds = true;
            button.Layer.CornerRadius = 2;

            button.SetBackgroundImage(ImageFromColor(AppColors.Accent), UIControlState.Normal);
            button.SetBackgroundImage(ImageFromColor(AppColors.Accent.Lighter(1.2f)), UIControlState.Highlighted);

            button.SetTitleColor(AppColors.White, UIControlState.Normal);
            button.TitleLabel.Font = UIFont.SystemFontOfSize(13, UIFontWeight.Medium);
            button.ContentEdgeInsets = new UIEdgeInsets(8, 10, 8, 10);
        }

        public static void StyleFlatButton(this UIButton button)
        {
            button.ClipsToBounds = true;
            button.Layer.CornerRadius = 2;

            button.SetBackgroundImage(ImageFromColor(AppColors.Transparent), UIControlState.Normal);
            button.SetBackgroundImage(ImageFromColor(AppColors.White.ChangeAlpha(0.1f)), UIControlState.Highlighted);

            button.SetTitleColor(AppColors.Accent, UIControlState.Normal);
            button.SetTitleColor(AppColors.Accent.Lighter(1.2f), UIControlState.Highlighted);
            button.TitleLabel.Font = UIFont.SystemFontOfSize(13, UIFontWeight.Medium);
            button.ContentEdgeInsets = new UIEdgeInsets(8, 10, 8, 10);
        }

        public static UIImage ImageFromColor(UIColor color, RectangleF rect = default(RectangleF))
        {
            if (rect.Equals(default(RectangleF)))
                rect = new RectangleF(0, 0, 1, 1);

            UIGraphics.BeginImageContext(rect.Size);

            var ctx = UIGraphics.GetCurrentContext();
            ctx.SetFillColor(color.CGColor);
            ctx.FillRect(rect);

            var img = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return img;
        }
    }
}
