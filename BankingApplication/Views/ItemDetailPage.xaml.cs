﻿using BankingApplication.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BankingApplication.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}