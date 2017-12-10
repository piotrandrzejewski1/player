using Foundation;
using System;
using UIKit;
using Player.IAdapters;
using GalaSoft.MvvmLight.Ioc;
using Player.Shared.Statics;

namespace Player.iOS.Vc
{
    public partial class MainVc : UIViewController
    {
        public MainVc (IntPtr handle) : base (handle)
        {
        }

        partial void GoToSettings_Click(UIButton sender)
        {
            SimpleIoc.Default.GetInstance<INavigationService>().Navigate(PageNames.Settings);
        }
    }
}