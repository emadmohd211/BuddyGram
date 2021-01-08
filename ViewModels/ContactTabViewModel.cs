using Buddiegram.Models;
using Buddiegram.Services;
using Buddiegram.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Buddiegram.ViewModels
{
    class ContactTabViewModel : BaseContactViewModel
    {
            IContactsService _contactService;
            private readonly INavigation Navigation;
        //  public event PropertyChangedEventHandler PropertyChang

        public string Title => "Contacts";

            public string SearchText { get; set; }
            public ObservableCollection<Contact> Contacts { get; set; }
            public ObservableCollection<Contact> selectedList;

            #region Commands

            private ICommand _NextButtonCommand;
            public ICommand NextButtonCommand
        {
                get { return _NextButtonCommand = _NextButtonCommand ?? new Command(NextButtonClicked); }
            }
        public ObservableCollection<Contact> FilteredContacts
            {
                get
                {
                    return string.IsNullOrEmpty(SearchText) ? Contacts : new ObservableCollection<Contact>(Contacts?.ToList()?.Where(s => !string.IsNullOrEmpty(s.Name) && s.Name.ToLower().Contains(SearchText.ToLower())));
                }
            }
            public ContactTabViewModel(IContactsService contactService, INavigation _navigation)
            {
                Navigation = _navigation;
                _contactService = contactService;
                Contacts = new ObservableCollection<Contact>();
                Xamarin.Forms.BindingBase.EnableCollectionSynchronization(Contacts, null, ObservableCollectionCallback);
                _contactService.OnContactLoaded += OnContactLoaded;
                LoadContacts();
            }


            void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
            {
                // `lock` ensures that only one thread access the collection at a time
                lock (collection)
                {
                    accessMethod?.Invoke();
                }
            }

            private void OnContactLoaded(object sender, ContactEventArgs e)
            {
                Contacts.Add(e.Contact);
            }
            async Task LoadContacts()
            {
                try
                {
                    await _contactService.RetrieveContactsAsync();
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("Task was cancelled");
                }
            }

         async void NextButtonClicked()
        {
            // Navigation.PopModalAsync(true);
            /*   var checkedItems = Items.Where(x => x.IsChecked == true).ToList();
               foreach (var item in checkedItems)
               {
                   // Do stuff with item
               }*/

            //DisplayAlert("title", myModel.Title + "OK");
            // DisplayAlert("title", myModel.Name + " " + myModel.IsChecked, "OK");

            selectedList = new ObservableCollection<Contact>();

            for (int i = 0; i < FilteredContacts.Count; i++)
            {
                Contact item = FilteredContacts[i];

                if (item.IsChecked)
                {
                    selectedList.Add(item);
                }
            }

            //  DisplayAlert("Title", selectedList.Count + " item have been selected", "Cancel");
            var contactList = new ContactList();

           // contactList.move();
            await  Navigation.PushAsync(new CreateMeetup(selectedList));
            
        }
        #endregion
    }
}
