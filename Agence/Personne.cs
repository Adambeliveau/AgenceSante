using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence
{
    public class Personne:INotifyPropertyChanged
    {
        string nom;
        string prenom;
        string numTel;
        string email;
        string adresse1;
        string adresse2;
        string ville;
        string province;
        string pays;
        string codeP;


        //set et get des parametres
        public string Nom { get => nom; set { if (this.nom != value) { this.nom = value; OnePropertyChanged(); } } }
        public string Prenom { get => prenom; set { if (this.prenom != value) { this.prenom = value; OnePropertyChanged(); } } }
        public string NumTel { get => numTel; set { if (this.numTel != value) { this.numTel = value; OnePropertyChanged(); } } }
        public string Email { get => email; set { if (this.email != value) { this.email = value; OnePropertyChanged(); } } }
        public string Adresse1 { get => adresse1; set { if (this.adresse1 != value) { this.adresse1 = value; OnePropertyChanged(); } } }
        public string Adresse2 { get => adresse2; set { if (this.adresse2 != value) { this.adresse2 = value; OnePropertyChanged(); } } }
        public string Ville { get => ville; set { if (this.ville != value) { this.ville = value; OnePropertyChanged(); } } }
        public string Province { get => province; set { if (this.province != value) { this.province = value; OnePropertyChanged(); } } }
        public string Pays { get => pays; set { if (this.pays != value) { this.pays = value; OnePropertyChanged(); } } }
        public string CodeP { get => codeP; set { if (this.codeP != value) { this.codeP = value; OnePropertyChanged(); } } }


        //format de l'affichage des parametres
        public string Description
        {
            get { return string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", nom, prenom, numTel, email, adresse1, adresse2, ville, province, pays, codeP); }
        }

        //pour si un parametre change de valeur
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnePropertyChanged(string propertyName=null)
        {
            if(this.PropertyChanged!=null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
