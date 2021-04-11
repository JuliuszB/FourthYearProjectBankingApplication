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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void Button_Clicked_Register(object sender, EventArgs e)
        {
            Person personToAdd = new Person();
            personToAdd.fName = EntryFirstName.Text;
            personToAdd.sName = EntryLastName.Text;
            personToAdd.phoneNo = EntryPhoneNo.Text;
            personToAdd.password = EntryPassword.Text;
            personToAdd.email = EntryEmail.Text;
            personToAdd.isLoggedIn = "true";
            Person.RunPost(personToAdd);
           // Navigation.PushAsync(new MainPage());
        }
    }
}