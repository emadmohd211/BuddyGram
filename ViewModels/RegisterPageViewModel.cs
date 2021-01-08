using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Buddiegram.ViewModels
{
    public class RegisterPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigation Navigation;

        public string PageTitle { get; }

        public RegisterPageViewModel(INavigation _navigation)
        {
            Navigation = _navigation;
            PageTitle = "Login";
        }

        #region Properties

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Firstname"));

            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Lastname"));

            }
        }

        private string _phonenumber;
        public string Phonenumber
        {
            get { return _phonenumber; }
            set
            {
                _password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Phonenumber"));

            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
              
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
               
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Commands

        private ICommand _signupCommand;
        public ICommand SignupCommand
        {
            get { return _signupCommand = _signupCommand ?? new Command(SignUpAction); }//, CanLoginAction); }
        }

        #region Methods

        async void SignUpAction()
        {
            if (string.IsNullOrWhiteSpace(this.Email) || string.IsNullOrWhiteSpace(this.Password) || string.IsNullOrWhiteSpace(this.Firstname) || string.IsNullOrWhiteSpace(this.Lastname))
            {
                MessagingCenter.Send(this, "Login Alert", "Please fill-up the form");
                return;
            }
            string x = "ddd";

           // IsBusy = true;

            //TODO - perform your login action + navigate to the next page
            await App.Dbmgr.RegisterTaskAsync(x);

            //Simulate an API call to show busy/progress indicator            
          //  Task.Delay(20000).ContinueWith((t) => IsBusy = false);

            //Show the Cancel button after X seconds
         //   Task.Delay(5000).ContinueWith((t) => IsShowCancel = true);
        }
        #endregion
    }
}
#endregion