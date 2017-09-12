﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServoIO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LedgerSubControlView : Grid
    {
        public LedgerSubControlView()
        {
            InitializeComponent();
        }
        public LedgerSubControlView(object item)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }
}
