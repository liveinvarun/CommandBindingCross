//
//  ViewController.cs
//
//  Author:
//       developer <Varun.ravindranath@cognizant.com>
//
//  Copyright (c) 2017 (c) Varun R
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace SampleApp
{
    [MvxFromStoryboard(StoryboardName = "Main")]

    public partial class ViewController : MvxViewController<SignInViewModel>
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (ViewModel == null)
            {
                ViewModel = new SignInViewModel();

            }
            var source = new SignInTableSource(loginTableView);
            var set = this.CreateBindingSet<ViewController, SignInViewModel>();
            set.Bind(source).To(vm => vm.LoggedInUser);
            set.Apply();



            //this.AddBindings(new Dictionary<object, string>
            //          {
            //              {source, "ItemsSource Animals"}
            //          });

            loginTableView.Source = source;
            loginTableView.ReloadData();


            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


}
