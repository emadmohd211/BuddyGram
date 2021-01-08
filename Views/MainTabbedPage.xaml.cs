using Buddiegram.Services;
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
    public partial class MainTabbedPage : TabbedPage
    {
        public static IContactsService MyContactInfo { get; private set; }
        public MainTabbedPage(IContactsService contactService)
        {
            MyContactInfo = contactService;
            InitializeComponent();

           

            //var x = new ContactListTab(contactService);
        }
    }
}