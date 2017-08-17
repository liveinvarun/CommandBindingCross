using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using SampleApp;

namespace SampleApp
{
    /// <summary>
    /// App start.
    /// </summary>
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public static bool LanguageSettingNeeded = false;

        public void Start(object hint = null)
        {
            ShowViewModel<SignInViewModel>();

        }
    }

}
