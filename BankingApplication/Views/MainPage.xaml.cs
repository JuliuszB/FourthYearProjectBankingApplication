using BankingApplication.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BankingApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        Person sessionUser = new Person();
        //List<BankAccount> userAccounts = new List<BankAccount>();
        public List<string> pickerSource { get; set; }
        public List<string> accountNames = new List<string>();
        public MainPage(Person fetchedUser,List<BankAccount> useraccounts)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            sessionUser = fetchedUser;
            nameLabel.Text = fetchedUser.fName;
            BindingContext = useraccounts;
            BankAccountListView.ItemsSource = useraccounts;
            foreach (BankAccount acc in useraccounts)
            {
                accountNames.Add(acc.accountName);
            }
           // var pickerSource = new Picker { Title = "Select Account" };
            accountPicker.ItemsSource = accountNames;

        }
        private void Button_Clicked_AddAccount(object sender, EventArgs e)
        {
            BankAccount accountToAdd = new BankAccount();
            accountToAdd.accountName = AccName.Text ;
            accountToAdd.accountNumber = AccNum.Text ;
            accountToAdd.accountOwner = sessionUser.phoneNo;
            accountToAdd.iban = iban.Text;
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