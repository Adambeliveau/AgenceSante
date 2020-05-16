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

namespace Agence
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnValider(object sender, RoutedEventArgs e)
        {
           
            //verif du mots de passe
            if (login.Password.ToString() == "AgenceSanté")
            {
                var window = new Window1();
                window.Show();
                window.Title = "bienvenu(e) " + identite.Text;
                this.Close();
            }
            //si le mot de passe nes pas correct
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Voulez-vous réessayer", "Login Invalide", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    login.Clear();
                    this.login.Focus();
                }
                else
                {
                    this.Close();
                }

            }
            
        }
        //lost focus pour les majuscule
        private void Fuser(object sender, RoutedEventArgs e)
        {
           if(identite.Text!="")
           {
           string oldText = string.Empty;
           oldText = identite.Text;
           string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
           identite.Text = MajusculeText;
           }
        }

    }
}
