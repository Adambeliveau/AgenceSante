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
using System.Windows.Shapes;

namespace Agence
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        //creation d'une liste temporaire
        public ListePersonne Lmembre;
        public Window2(ListePersonne Membre)
        {
            InitializeComponent();

            //initialisation de la liste temporaire 
            Lmembre = Membre;
        }

        //pour ajouter un contact
        private void btnOk(object sender, RoutedEventArgs e)
        {
            //variable pour savoir si le contact existe déjà
            bool isDuplicate;
            //initialisation de la variable 
            isDuplicate = false;

            //verif pour la duplication de contact
            for (int i = 0; i < Lmembre.Count(); i++)
            {
                if (Lmembre[i].Nom == TNom.Text && Lmembre[i].Prenom == TPrenom.Text)
                    isDuplicate = true;

            }

            //si il n'est pas dupliquer ajout du contact dans la liste
            if (isDuplicate == false)
            {
                if (TNom.Text == "" || TPrenom.Text == "" || TTel.Text == "")
                {
                    MessageBox.Show("Vous devez entrer le nom, le prenom et le numéro de téléphone");
                }
                else
                {
                    Lmembre.Add(new Personne()
                    {
                        Nom = TNom.Text,
                        Prenom = TPrenom.Text,
                        NumTel = TTel.Text,
                        Adresse1 = TAdre1.Text,
                        Adresse2 = TAdre2.Text,
                        Ville = Tville.Text,
                        Province = TProv.Text,
                        Pays = TPays.Text,
                        Email = TEmail.Text,
                        CodeP = TCP.Text,
                    });
                    MessageBox.Show("Contact ajouter avec Succès!!");
                    this.Close();
                }
            }
            //si le contact est dupliquer un message est envoyer et l'utilisateur doit recommencer
            if(isDuplicate==true)
            {
                MessageBox.Show("Le contact existe deja! Veuillez en entrer un nouveau.");
            }
            
        }

        //si l'utilisateur ne veux plus ajouter de contact est quitter la fenêtre
        private void btnAnnuler(object sender, RoutedEventArgs e)
        {
            var window = new Window1();
            MessageBoxResult messageBoxResult = MessageBox.Show("Êtes-vous sur de vouloir Annuler?", "Fermeture de la boîte d'enregistrement", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                window.Show();
                this.Close();
            }
          
            
        }


        //lost focus pour les majuscule de ici à ==>
        private void Fnom(object sender, RoutedEventArgs e)
        {
            if (TNom.Text != "")
            {
                string oldText = string.Empty;
                oldText = TNom.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TNom.Text = MajusculeText;

            }
        }

        private void Fprenom(object sender, RoutedEventArgs e)
        {
            if (TPrenom.Text != "")
            {
                string oldText = string.Empty;
                oldText = TPrenom.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TPrenom.Text = MajusculeText;

            }
        }

        private void FAdre1(object sender, RoutedEventArgs e)
        {
            if (TAdre1.Text != "")
            {
                string oldText = string.Empty;
                oldText = TAdre1.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TAdre1.Text = MajusculeText;

            }
        }

        private void Fadre2(object sender, RoutedEventArgs e)
        {
            if (TAdre2.Text != "")
            {
                string oldText = string.Empty;
                oldText = TAdre2.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TAdre2.Text = MajusculeText;

            }
        }

        private void FVille(object sender, RoutedEventArgs e)
        {
            if (Tville.Text != "")
            {
                string oldText = string.Empty;
                oldText = Tville.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                Tville.Text = MajusculeText;

            }
        }

        private void FProvince(object sender, RoutedEventArgs e)
        {
            if (TProv.Text != "")
            {
                string oldText = string.Empty;
                oldText = TProv.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TProv.Text = MajusculeText;

            }
        }

        private void FPays(object sender, RoutedEventArgs e)
        {
            if (TPays.Text != "")
            {
                string oldText = string.Empty;
                oldText = TPays.Text;
                string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
                TPays.Text = MajusculeText;

            }
        }

        private void FCP(object sender, RoutedEventArgs e)
        {
            TCP.Text = TCP.Text.ToUpper();
        }
        //==> ici
    }
}
