using Buddiegram.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Buddiegram.ViewModels
{
   
    public class MeetUpViewModel
    {
        public ObservableCollection<Contact> selectedContacts { get; set; }
        public MeetUpViewModel(ObservableCollection<Contact> addedContacts)
        {
            selectedContacts = new ObservableCollection<Contact>();

            for (int i = 0; i < addedContacts.Count; i++)
            {
                Contact item = addedContacts[i];

                if (item.IsChecked)
                {
                    selectedContacts.Add(item);
                }
            }
        }
    }
}
