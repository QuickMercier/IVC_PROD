﻿using FirstFloor.ModernUI.Windows;
using NeoTracker.Content;
using NeoTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Navigation;
using NeoTracker.DAL;
using System.Data.Entity;
using static NeoTracker.ViewModels.MainViewModel;
using NeoTracker.Pages.Dialogs;

namespace NeoTracker.Pages.Admin
{
    /// <summary>
    /// Interaction logic for DepartmentEdit.xaml
    /// </summary>
    public partial class ProjectTypeEdit : UserControl, IContent
    {
        private Buttons btn = new Buttons();

        public ProjectTypeEdit()
        {
            InitializeComponent();
            btn.SetButton(ApplyButton, true, "Apply", null, null);
            btn.SetButton(DeleteButton, true, "Delete", null, null);
            btn.SetButton(CancelButton, true, "Cancel", null, null);
        }

        private async void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            await App.vm.ProjectType.Save();
            App.vm.ProjectType = null;
            App.nav.GoBack(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.vm.ProjectType.CancelEdit();
            App.vm.ProjectType = null;
            App.nav.GoBack(this);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            await App.vm.ProjectType.Delete();
            App.vm.ProjectType = null;
            App.nav.GoBack(this);
        }
        public void OnFragmentNavigation(FirstFloor.ModernUI.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(FirstFloor.ModernUI.Windows.Navigation.NavigationEventArgs e)
        {
            App.vm.ProjectType.BeginEdit();
            App.nav.SetLastUri("/Pages/Admin/ProjectTypeEdit.xaml");
        }
        public void OnNavigatingFrom(FirstFloor.ModernUI.Windows.Navigation.NavigatingCancelEventArgs e)
        {
        }
    }
}
