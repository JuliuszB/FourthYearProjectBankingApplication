using BankingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankingApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage(Person fetchedUser)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
             Person user = fetchedUser;
            nameLabel.Text = fetchedUser.fName;
        }
        private void Button_Clicked_AddAccount(object sender, EventArgs e)
        {

        }
        private void Button_Clicked_TransferFunds(object sender, EventArgs e)
        {
            
        }
    }
}