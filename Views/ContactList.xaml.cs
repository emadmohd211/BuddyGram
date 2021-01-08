using Buddiegram.Models;
using Buddiegram.Services;
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
    public partial class ContactList : ContentPage
    {
        IContactsService _contactService;

       /// public ObservableCollection<Item> veggies { get; set; }
        public ObservableCollection<Contact> _ContactList { get; set; }
        public ObservableCollection<Contact> selectedList;
        public ContactList()
        {
            InitializeComponent();
            _contactService = MainTabbedPage.MyContactInfo;
            BindingContext = new ContactTabViewModel(_contactService, Navigation);

        }
        /*
      async void NextButtonClicked(object sender, EventArgs e)
      {
          // Navigation.PopModalAsync(true);
          /*   var checkedItems = Items.Where(x => x.IsChecked == true).ToList();
             foreach (var item in checkedItems)
             {
                 // Do stuff with item
             }*/

        //DisplayAlert("title", myModel.Title + "OK");
        // DisplayAlert("title", myModel.Name + " " + myModel.IsChecked, "OK");
        /*
        selectedList = new ObservableCollection<Contact>();

            for (int i = 0; i < FilteredContacts.Count; i++)
            {
                Contact item = _ContactList[i];

                if (item.IsChecked)
                {
                    selectedList.Add(item);
                }
            }

          //  DisplayAlert("Title", selectedList.Count + " item have been selected", "Cancel");
            await Navigation.PushAsync(new CreateMeetup());
        }

           private void CheckBox_CheckChanged(object sender, EventArgs e)
             {
                 selectedList = new ObservableCollection<Contact>();

                 for (int i = 0; i < _ContactList.Count; i++)
                 {
                     Contact item = _ContactList[i];

                     if (item.ROWCHECK)
                     {
                         selectedList.Add(item);
                     }
                 }

                 DisplayAlert("Title", selectedList.Count + " item have been selected", "Cancel");

                 // do something you want 

             }  */

       

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var myModel = e.SelectedItem as Contact;
            //DisplayAlert("title", myModel.Title + "OK");
            DisplayAlert("title", myModel.Name + " " + myModel.IsChecked, "OK");
            string s = "jj";
        }

    }
}