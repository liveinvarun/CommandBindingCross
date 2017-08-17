// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace SampleApp
{
    [Register("LoginCell")]
    partial class LoginCell
    {
        [Outlet]
        UIKit.UIButton cancelBtn { get; set; }


        [Outlet]
        UIKit.UITextField emailField { get; set; }


        //[Outlet]
        //UIKit.UITextField passwordField { get; set; }


        [Outlet]
        UIKit.UIButton signInBtn { get; set; }

        [Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        SampleApp.FloatingTextField passwordField { get; set; }


        void ReleaseDesignerOutlets()
        {
            if (cancelBtn != null)
            {
                cancelBtn.Dispose();
                cancelBtn = null;
            }

            if (emailField != null)
            {
                emailField.Dispose();
                emailField = null;
            }

            if (passwordField != null)
            {
                passwordField.Dispose();
                passwordField = null;
            }

            if (passwordField != null)
            {
                passwordField.Dispose();
                passwordField = null;
            }

            if (signInBtn != null)
            {
                signInBtn.Dispose();
                signInBtn = null;
            }
        }
    }
}