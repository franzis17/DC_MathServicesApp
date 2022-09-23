﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
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

using Authenticator;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private IAuth auth;

        // TextBox values
        private string username;
        private string password;

        public RegisterPage()
        {
            InitializeComponent();

            GUI_Utility.HideStatusLabel(RegStatusLabel);

            auth = AuthenticatorSingleton.GetInstance();
        }

        private async void RegUserBtn_Click(object sender, RoutedEventArgs e)
        {
            GUI_Utility.HideStatusLabel(RegStatusLabel);
            
            username = RegUserTxtBox.Text;
            password = RegPassTxtBox.Text;

            Task<string> registerTask = new Task<String>(Register);
            registerTask.Start();

            try
            {
                string regStatus = await registerTask;
                GUI_Utility.ShowStatusLabel(RegStatusLabel, regStatus);
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                string errorMsg = "Error: Authenticator Server might not be online.\n\t";
                GUI_Utility.ShowErrorStatusLabel(RegStatusLabel, errorMsg);
            }
        }

        private string Register()
        {
            return auth.Register(username, password);
        }
    }
}
