﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HP_MSA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StorageList : ContentPage
    {
        public StorageList(string companyName)
        {
            InitializeComponent();
        }
    }
}