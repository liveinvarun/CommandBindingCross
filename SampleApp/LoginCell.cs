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
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<LoginCell, UserViewModel>();
                set.Bind(emailField).To(p => p.UserName);
                //set.Bind().For(t => t.passwordField).To(p => p.Password);

                set.Bind(signInBtn.Tap()).For(c => c.Command).To(p => p.SignInCommand);
                set.Apply();

                var set2 = this.CreateBindingSet<LoginCell, UserViewModel>();
                //  set2.Bind(emailField).To(p => p.UserName);
                //set.Bind().For(t => t.passwordField).To(p => p.Password);

                set2.Bind(signInBtn).For(c => c.Enabled).To(p => p.CanExecute);
                set2.Apply(); ;
            });

        }

        internal void UpateCell()
        {
            ((FloatingTextField)emailField).IsUnderLined = true;


            //            signInBtn.TouchUpInside += (s, e) =>
            //            {
            //
            //            };

        }


    }
}