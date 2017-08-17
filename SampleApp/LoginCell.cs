using Foundation;
using System;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views.Gestures;
using SampleApp.Portable;

namespace SampleApp
{
    public partial class LoginCell : MvxTableViewCell
    {
        public LoginCell(IntPtr handle) : base(handle)
        {


        }

        internal void UpateCell()
        {
            ((FloatingTextField)emailField).IsUnderLined = true;

            var set = this.CreateBindingSet<LoginCell, UserViewModel>();
            set.Bind(emailField).To(p => p.UserName);
            //set.Bind().For(t => t.passwordField).To(p => p.Password);

            set.Bind(signInBtn).To(p => p.SignInCommand).TwoWay();
            set.Apply();
            //            signInBtn.TouchUpInside += (s, e) =>
            //            {
            //
            //            };

        }


    }
}