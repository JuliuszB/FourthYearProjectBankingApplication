using BankingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static BankingApplication.Models.Person;

namespace BankingApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //Login button - logs a user in if the account exists
        private async void Button_Clicked(object sender, EventArgs e)
        {
            loginCredentials UsertoLogIn = new loginCredentials(LogInPhoneNo.Text, LogInPass.Text);
            Person fetchedUser = await Person.getUser(UsertoLogIn);
            try
            {
                if (fetchedUser.password == UsertoLogIn.password && fetchedUser.phoneNo == UsertoLogIn.phoneNo)
                {
                    Navigation.PushAsync(new MainPage(fetchedUser));
                }
                
            }
           catch (NullReferenceException)
            {
                await DisplayAlert("Incorrect Details", "The phone number / password combination you have entered " +
                        "is not correct, try again or register a new account", "OK");
                Navigation.PushAsync(new LoginPage());
            }
            
        }

        //Register button - brings you to register page
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}