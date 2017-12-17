using System;
using System.Collections.Generic;
using UIKit;
using Player.Shared.Statics;
using Player.IAdapters;

namespace Player.iOS.Adapters
{
    public class NavigationService : INavigationService
    {
        public UINavigationController NavigationController { get; private set; }
        private Dictionary<PageNames, UIViewController> _definedPages;

        public void SetNavigationController(UINavigationController controller)
        {
            NavigationController = controller;
        }

        public void SetPagesDictionary(Dictionary<PageNames, UIViewController> definedPages)
        {
            _definedPages = definedPages;
        }

        public void GoBack(bool animated = true)
        {
            new UIViewController().InvokeOnMainThread(() =>
            {
                NavigationController.PopViewController(animated);
            });
        }

        public void Navigate(PageNames uri, bool animated = true)
        {
            NavigationController.PushViewController(_definedPages[uri], animated);
        }

        public void PopAllFromBackstack()
        {
            var controllers = NavigationController.ViewControllers;
            var controllersLength = controllers.Length;

            if (controllersLength == 0)
                return;

            if (controllersLength == 1)
                return;

            var controllerToSetup = controllers[controllers.Length - 1];
            NavigationController.ViewControllers = new UIViewController[] { controllerToSetup };
            for (int i = 0; i < controllersLength; i++)
            {
                if (controllers[i] != controllerToSetup)
                    controllers[i].Dispose();
            }
        }

        public void PopFromBackstack()
        {
            var controllers = NavigationController.ViewControllers;

            if (controllers.Length == 0)
                return;

            if (controllers.Length == 1)
                return;

            var newControllers = new List<UIViewController>();
            for (int i = 0; i < controllers.Length; i++)
            {
                if (i != controllers.Length - 2)
                    newControllers.Add(controllers[i]);
            }
            NavigationController.ViewControllers = newControllers.ToArray();
        }
    }
}
