﻿using Caliburn.Micro;
using SMRDesktopUI.EventModels;
using SMRDesktopUI.Helpers;
using SMRDesktopUI.Library.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMRDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName ;
        private string _password ;
        private IAPIHelper _apiHelper;
        //private bool _isErrorVisible;
        private string _errorMessage;
        private IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper, IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }

        public string UserName
        {
            get { return _userName;  }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                NotifyOfPropertyChange(() => CanLogin);

            }
        }

        public bool IsErrorVisible
        {
            get 
            {
                bool output = false;

                if(ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;  
            }
            
            
        }

        public string ErrorMessage
        {
            get { return _errorMessage;  }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);
                
            }
        }

        public bool CanLogin
        {
            get
                {
                bool output = false;

                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }

                return output;

            }
            
        }

        public async Task Login()
        {
             Console.WriteLine();
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);

                //Capture more information about the user
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);

                await _events.PublishOnUIThreadAsync(new LogOnEventModel());


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
 