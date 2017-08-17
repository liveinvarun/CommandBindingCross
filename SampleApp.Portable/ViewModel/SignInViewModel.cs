//
//  SignInViewModel.cs
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
using System;
using MvvmCross.Core.ViewModels;
using SampleApp.Portable;

namespace SampleApp
{
    public class SignInViewModel : MvxViewModel
    {
        UserViewModel _user = null;
        public SignInViewModel()
        {
            _user = new UserViewModel();

        }

        void OnSignInExecuted()
        {

        }

        /// <summary>
        /// Gets or sets the logged in user.
        /// </summary>
        /// <value>The logged in user.</value>
        public UserViewModel LoggedInUser
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                RaisePropertyChanged(() => LoggedInUser);
            }
        }



    }
}
