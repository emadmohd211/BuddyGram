using Buddiegram.Services;
using Buddiegram.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Buddiegram.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListTab : ContentPage
    {
         IContactsService _contactService;

        public ContactListTab()
        {
            InitializeComponent();
            _contactService = MainTabbedPage.MyContactInfo;
            BindingContext = new ContactTabViewModel(_contactService,Navigation);

        }
     /*   public ContactListTab()
        {

           
            
            // ContactTabViewModel x =
        }*/
     

      



    }
}