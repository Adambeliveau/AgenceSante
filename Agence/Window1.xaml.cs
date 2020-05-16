using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //création de la liste
        public ListePersonne Membre = new ListePersonne();
        
        public Window1()
        {
            InitializeComponent();
            this.DataContext = Membre;//liaison des donnees a la liste
        }

        //ouverture de la fenêtre d'ajout de contact
        private void btnNouveau(object sender, RoutedEventArgs e)
        {
            var window = new Window2(Membre);
            window.Show();
           
        }

        //lost focus pour les majuscule de ici à ==>
        private void FNom(object sender, RoutedEventArgs e)
        {
            if(TNom.Text!="")
            {
            string oldText = string.Empty;
            oldText = TNom.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TNom.Text = MajusculeText;

            }
        }

        private void Fprenom(object sender, RoutedEventArgs e)
        {
            if (TPrenom.Text!="")
            {
            string oldText = string.Empty;
            oldText = TPrenom.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TPrenom.Text = MajusculeText;
            }
        }

        private void Ftel(object sender, RoutedEventArgs e)
        {
           
        }

        private void Fadresse1(object sender, RoutedEventArgs e)
        {
            if(TAdre1.Text!="")
            {
            string oldText = string.Empty;
            oldText = TAdre1.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TAdre1.Text = MajusculeText;

            }
        }

        private void Fadresse2(object sender, RoutedEventArgs e)
        {
            if(TAdre2.Text!="")
            {
            string oldText = string.Empty;
            oldText = TAdre2.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TAdre2.Text = MajusculeText;
            }
        }

        private void Fville(object sender, RoutedEventArgs e)
        {
            if(Tville.Text!="")
            {
            string oldText = string.Empty;
            oldText = Tville.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            Tville.Text = MajusculeText;

            }
        }

        private void Fprovince(object sender, RoutedEventArgs e)
        {
            if(TProv.Text!="")
            {
            string oldText = string.Empty;
            oldText = TProv.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TProv.Text = MajusculeText;

            }
        }

        private void Fpays(object sender, RoutedEventArgs e)
        {
            if(TPays.Text!="")
            {
            string oldText = string.Empty;
            oldText = TPays.Text;
            string MajusculeText = oldText[0].ToString().ToUpper() + oldText.Substring(1).ToLower();
            TPays.Text = MajusculeText;

            }
        }

        private void FCP(object sender, RoutedEventArgs e)
        {
            if (TCP.Text != "")
            {
            TCP.Text=TCP.Text.ToUpper();

            }
        }
        //==> ici

        //recherche du nom
        private void btnRechercher(object sender, RoutedEventArgs e)
        {
            //i c'est pour savoir si il n'y a pas d'element correspondant à la recherche
            int i = 0;
            //recherche dans la liste par item
            foreach(Personne item in Membre)
            {
                if(item.Nom==Recherche.Text)
                {
                    NameList.SelectedItem = item;
                    i++;
                }
            }
            //si i = 0 aucun item ne correspond à la recherche 
                if(i==0)
                {
                    MessageBox.Show("Personne introuvable");
                }
        }

        //supprimer le contact selectionner
        private void btnSupprimer(object sender, RoutedEventArgs e)
        {
            var ligne = (Personne)NameList.SelectedItem;
            Membre.Remove(Membre.First(s => s.Nom == ligne.Nom));
            MessageBox.Show("Contact supprimer avec succès");
        }

        //sauvegarde dans le fichier.txt de la liste de contact
        private void btnSauvegarde(object sender, RoutedEventArgs e)
        {
            StreamWriter ecrire = new StreamWriter("fichier.txt");
            string line = string.Empty;

            //verif si l'enregistrement est possible
            bool verifenregistrement;
            verifenregistrement = true;
            foreach(Personne item in Membre)
            {
                if (item.Nom.Length == 0 || item.Prenom.Length == 0 || item.NumTel.Length == 0)
                {
                    MessageBox.Show("Vous devez entrer le nom, le prénom et le numéro de téléphone");
                    verifenregistrement = false;
                }
                else
                {
                    line=string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", item.Nom, item.Prenom, item.NumTel, item.Email, item.Adresse1, item.Adresse2, item.Ville, item.Province, item.Pays, item.CodeP);
                    ecrire.WriteLine(line);
                }

            }
            if (verifenregistrement == true)
            {
                MessageBoxResult messages = MessageBox.Show("enregistrement effectué");
                ecrire.Flush();
                ecrire.Close();
            }
        }

        //pour quitter le programme
        private void btnQuitter(object sender, RoutedEventArgs e)
        {
            //choix pour si l'utilisateur veux sauvegarder avant de quitter le programme
            MessageBoxResult message = MessageBox.Show("Voulez-vous enregistrer", "Enregistrement", MessageBoxButton.YesNo);
            if(message==MessageBoxResult.Yes)
            {
                StreamWriter ecrire = new StreamWriter("fichier.txt");
                string line = string.Empty;

                //si l'enregistrement est possible
                bool verifenregistrement;
                verifenregistrement = true;
                foreach (Personne item in Membre)
                {
                    if (item.Nom.Length == 0 || item.Prenom.Length == 0 || item.NumTel.Length == 0)
                    {
                        MessageBox.Show("Vous devez entrer le nom, le prénom et le numéro de téléphone");
                        verifenregistrement = false;
                    }
                    else
                    {
                        line = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9}", item.Nom, item.Prenom, item.NumTel, item.Email, item.Adresse1, item.Adresse2, item.Ville, item.Province, item.Pays, item.CodeP);
                        ecrire.WriteLine(line);
                    }

                }
                if (verifenregistrement == true)
                {
                    MessageBoxResult messages = MessageBox.Show("enregistrement effectué");
                    ecrire.Flush();
                    ecrire.Close();
                    this.Close();
                }
            }
            
        }
    }
}
