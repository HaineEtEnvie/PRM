﻿using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            user.ItemsSource = Singletone.DB.User.ToList();
        }

        private void Otmena(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save (object sender, RoutedEventArgs e)
        {
            Singletone.DB.SaveChanges();
        }
        private void Plus1(object sender, RoutedEventArgs e)
        {
            if (user.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя");
                return;
            }
            else
            {
                User Selectuser = user.SelectedItem as User;
                Selectuser.Role.Add(NeRole.SelectedItem as Role);
                UpdateListBox();
            }
        }

        private void PlusAll(object sender, RoutedEventArgs e)
        {
            if (user.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя");
                return;
            }
            else
            {
                User selectuser = user.SelectedItem as User;
                foreach (var nerole in NeRole.Items)
                {
                    selectuser.Role.Add(nerole as Role);
                }
                UpdateListBox();
            }
        }
        private void Minus1(object sender, RoutedEventArgs e)
        {
            if (user.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя");
                return;
            }
            else
            {
                User Selectuser = user.SelectedItem as User;
                Selectuser.Role.Remove(DaRole.SelectedItem as Role);
                UpdateListBox();
            }
        }
        private void MinusAll(object sender, RoutedEventArgs e)
        {
            if (user.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя");
                return;
            }
            else
            {
                User selectuser = user.SelectedItem as User;
                selectuser.Role.Clear();
                UpdateListBox();
            }
        }

        private void NeRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListBox();
        }
        private void UpdateListBox()
        {
            User Selectuser = user.SelectedItem as User;
            DaRole.ItemsSource = Selectuser.Role.ToList();
            List<Role> vseRole = Singletone.DB.Role.ToList();
            foreach (Role role in Selectuser.Role) 
            {
                vseRole.Remove(role);
            }
            NeRole.ItemsSource = vseRole;
        }
    }
}
