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
        Person sessionUser = new Person();
        public MainPage(Person fetchedUser)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            sessionUser = fetchedUser;
            nameLabel.Text = fetchedUser.fName;
        }
        private void Button_Clicked_AddAccount(object sender, EventArgs e)
        {
            BankAccount accountToAdd = new BankAccount();
            accountToAdd.accountName = AccName.Text ;
            accountToAdd.accountNumber = AccNum.Text ;
            accountToAdd.accountOwner = sessionUser.phoneNo;
            accountToAdd.IBAN = iban.Text;
            accountToAdd.balance = 0.0;
            BankAccount.RunPost(accountToAdd);
        }
        private void Button_Clicked_TransferFunds(object sender, EventArgs e)
        {
            
        }

        private async void Button_Clicked_Logout(object sender, EventArgs e)
        {

            try
            {
                   
                sessionUser.isLoggedIn = "False";
                    Person.RunPut(sessionUser);
                    await DisplayAlert("Logged Out Successfully", "Goodbye ! " + sessionUser.fName, "Leave");
                    Navigation.PushAsync(new LoginPage());

            }
            catch (NullReferenceException)
            {
                await DisplayAlert("Error", "session expired, please log in again", "OK");
                Navigation.PushAsync(new LoginPage());
            }

        }
    }
}