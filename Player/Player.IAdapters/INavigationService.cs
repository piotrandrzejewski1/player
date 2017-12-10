using System;
using Player.Shared.Statics;

namespace Player.IAdapters
{
    public interface INavigationService
    {
        void Navigate(PageNames uri, bool animated = true);
        void GoBack(bool animated = true);
        void PopFromBackstack();
        void PopAllFromBackstack();
    }
}
