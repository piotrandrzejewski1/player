using Foundation;
using System;
using UIKit;
using Player.iOS.Adapters;
using GalaSoft.MvvmLight.Ioc;
using Player.IAdapters;
using Player.Shared.Statics;

namespace Player.iOS.Vc
{
    public partial class PreappVc : UIViewController
    {
        public PreappVc (IntPtr handle) : base (handle)
        {
        }

        partial void GoToMainButton_Click(UIButton sender)
        {
            SimpleIoc.Default.GetInstance<INavigationService>().Navigate(PageNames.Main);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ((NavigationService) SimpleIoc.Default.GetInstance<INavigationService>()).SetNavigationController(NavigationController);
        }
    }
}