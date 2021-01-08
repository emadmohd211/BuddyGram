using Buddiegram.Models;
using Buddiegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Buddiegram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMeetup : ContentPage
    {
       
        public ObservableCollection<Contact> addedContacts { get; set; }
        public CreateMeetup(ObservableCollection<Contact> addedContacts)
        {
           
            InitializeComponent();
            this.BindingContext = new MeetUpViewModel(addedContacts);
        }

        async void CreateButtonClicked(object sender, EventArgs e)
        {
            // Navigation.PopModalAsync(true);
            await Navigation.PopToRootAsync();
        }
    }
}