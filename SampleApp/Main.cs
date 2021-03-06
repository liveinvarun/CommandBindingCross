//
//  Main.cs
//
//  Author:
//       developer  
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
using Foundation;
using UIKit;

namespace SampleApp
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {

            #region LanguageChange 
            //var defaults = NSUserDefaults.StandardUserDefaults;
            //defaults.SetString("he", "AppleLanguages");


            //NSUserDefaults.StandardUserDefaults.SetValueForKey(NSArray.FromStrings("he"), new NSString("AppleLanguages"));
            //defaults.Synchronize();
            //NSUserDefaults.StandardUserDefaults.Synchronize();
            #endregion
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
