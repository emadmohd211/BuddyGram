using Buddiegram.Data;
using Buddiegram.Services;
using Buddiegram.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Buddiegram
{
    public partial class App : Application
    {
        static BuddyUserDatabase database;
        public static DbManager Dbmgr { get; private set; }
        public App(IContactsService contactService)
        {
            InitializeComponent();
            Dbmgr = new DbManager(new DatabaseService());
            MainPage = new MainTabbedPage(contactService); //ContactListTab(contactService);// MainTabbedPage(contactService);// LoginPage();// MainPage();
        }

        public static BuddyUserDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BuddyUserDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
