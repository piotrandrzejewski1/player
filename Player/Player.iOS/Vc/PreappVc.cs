using Foundation;
using System;
using UIKit;
using Player.iOS.Adapters;
using GalaSoft.MvvmLight.Ioc;
using Player.IAdapters;
using Player.Shared.Statics;
using Player.iOS.Helpers;

namespace Player.iOS.Vc
{
    public partial class PreappVc : UIViewController
    {
        public PreappVc (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(true, false);
            TableView.RowHeight = UITableView.AutomaticDimension;
            TableView.EstimatedRowHeight = 100;
            TableView.Source = new PreappTableViewSource();
            TableView.AllowsSelection = false;
            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            SetStyles();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ((NavigationService) SimpleIoc.Default.GetInstance<INavigationService>()).SetNavigationController(NavigationController);
        }

        void SetStyles()
        {
            View.BackgroundColor = AppColors.PageBackground;
            MainContainer.BackgroundColor = AppColors.GrayBackground;
            TableView.BackgroundColor = AppColors.GrayBackground;
            RateButton.StyleStandardButton();
            DismissButton.StyleFlatButton();
            RateButton.SetTitle("RATE US ON GOOGLE PLAY", UIControlState.Normal);
            DismissButton.SetTitle("DISMISS", UIControlState.Normal);
        }
    }

    internal class PreappTableViewSource : UITableViewSource
    {
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if(indexPath.Section == 0)
            {
                var cell = (WhatsNewImageCell)tableView.DequeueReusableCell("WhatsNewImageCell", indexPath);
                return cell;
            }
            else
            {
                var cell = new UITableViewCell();
                cell.TextLabel.Text = indexPath.Section + " " + indexPath.Row;
                return cell;
            }
        }


        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (section == 0)
                return 1;
            if (section == 1)
                return 2;

            return 0;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }
    }
}