using Buddiegram.Views;
using Buddiegram.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.FacebookClient;
using Newtonsoft.Json;
using System.Diagnostics;
using Buddiegram.Models;

namespace Buddiegram.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigation Navigation;

        public string PageTitle { get; }

        public LoginPageViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            PageTitle = "Login";
        }

        #region Properties

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
                // if (SetPropertyValue(ref _email, value))
            //    {
              //      ((Command)LoginCommand).ChangeCanExecute();
             //   }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
                // if (SetPropertyValue(ref _password, value))
              //  {
             //       ((Command)LoginCommand).ChangeCanExecute();
             //   }
            }
        }

        private bool _isShowCancel;
        public bool IsShowCancel
        {
            get { return _isShowCancel; }
            set {
                /*SetPropertyValue(ref _isShowCancel, value);*/
                _isShowCancel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("IsShowCancel"));
            }
        }

        #endregion


        #region Commands

        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get { return _loginCommand = _loginCommand ?? new Command(LoginAction); }//, CanLoginAction); }
        }

        private ICommand _cancelLoginCommand;
        public ICommand CancelLoginCommand
        {
            get { return _cancelLoginCommand = _cancelLoginCommand ?? new Command(CancelLoginAction); }
        }

        private ICommand _forgotPasswordCommand;
        public ICommand ForgotPasswordCommand
        {
            get { return _forgotPasswordCommand = _forgotPasswordCommand ?? new Command(ForgotPasswordAction); }
        }

        private ICommand _newAccountCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NewAccountCommand
        {
            get { return _newAccountCommand = _newAccountCommand ?? new Command(NewAccountAction); }
        }

        IFacebookClient _facebookService = CrossFacebookClient.Current;
        private ICommand _onLoginWithFacebookCommand;
        public ICommand OnLoginWithFacebookCommand
        {
            get { return _onLoginWithFacebookCommand = new Command(async () => await LoginFacebookAsync()); }

        }

        public bool IsBusy { get; private set; }

        #endregion


        #region Methods

        bool CanLoginAction()
        {
            //Perform your "Can Login?" logic here...

            if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password))
                return false;

            return true;
        }
        async Task LoginFacebookAsync()
        {
            //Perform your "Can Login?" logic here...
            try
            {

                if (_facebookService.IsLoggedIn)
                {
                    _facebookService.Logout();
                }

                EventHandler<FBEventArgs<string>> userDataDelegate = null;

                userDataDelegate = async (object sender, FBEventArgs<string> e) =>
                {
                    if (e == null) return;

                    switch (e.Status)
                    {
                          case FacebookActionStatus.Completed:
                            var facebookProfile = await Task.Run(() => JsonConvert.DeserializeObject<FacebookProfile>(e.Data));
                            var socialLoginData = new NetworkAuthData
                            {
                                Email = facebookProfile.Email,
                                Name = $"{facebookProfile.FirstName} {facebookProfile.LastName}",
                                Id = facebookProfile.Id
                            };
                            await App.Current.MainPage.Navigation.PushModalAsync(new MainMenuPage());
                            break;
                        case FacebookActionStatus.Canceled:
                            break;
                    }

                    _facebookService.OnUserData -= userDataDelegate;
                };

                _facebookService.OnUserData += userDataDelegate;

                string[] fbRequestFields = { "email", "first_name", "gender", "last_name" };
                string[] fbPermisions = { "email" };
                await _facebookService.RequestUserDataAsync(fbRequestFields, fbPermisions);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    


        async void LoginAction()
        {
            if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password))
            {
                MessagingCenter.Send(this, "Login Alert", "Please fill-up the form");
                return;
            }
            //   var userlogin = (UserLogin)BindingContext;
            var userlogin = new UserLogin
            {
                email = this.Email,
                password = this.Password,
                logintype = "email"
        };
            

            IsBusy = true;
        //    MessageBox.Show(userlogin);
            //TODO - perform your login action + navigate to the next page
            await App.Dbmgr.LoginTaskAsync(userlogin);

            //Simulate an API call to show busy/progress indicator            
           // Task.Delay(20000).ContinueWith((t) => IsBusy = false);

            //Show the Cancel button after X seconds
           // Task.Delay(5000).ContinueWith((t) => IsShowCancel = true);
        }

        void CancelLoginAction()
        {
            //TODO - perform cancellation logic

            IsBusy = false;
            IsShowCancel = false;
        }

        void ForgotPasswordAction()
        {
            //TODO - navigate to your forgotten password page
            //Navigation.PushAsync(XXX);
        }

      //  public ICommand BackToPage { get; private set; }
        void NewAccountAction()
        {
            //TODO - navigate to your registration page
            Navigation.PushModalAsync(new RegisterPage());
      //      BackToPage = new Command(async () => {
             //   await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
          //  });
        }

        #endregion

    }
}
