using Foundation;
using System;
using UIKit;
using GalaSoft.MvvmLight.Ioc;
using Player.IAdapters;

namespace Player.iOS.Vc
{
    public partial class SettingsVc : UIViewController
    {
        public SettingsVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SimpleIoc.Default.GetInstance<INavigationService>().PopAllFromBackstack();
        }

        partial void GoBack_Click(UIButton sender)
        {
            SimpleIoc.Default.GetInstance<INavigationService>().GoBack();
        }
    }
}