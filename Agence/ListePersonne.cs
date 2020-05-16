using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agence
{
    public class ListePersonne:ObservableCollection<Personne>
    {
        public ListePersonne()
        {

            //Lecture du fichier.txt
            StreamReader sr;
            sr = new StreamReader("fichier.txt");
            while(!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var elements = line.Split(';');

                //ajout des contact existant sur le fichier
                Add(new Personne()
                {
                    Nom = elements[0],
                    Prenom = elements[1],
                    NumTel = elements[2],
                    Email = elements[3],
                    Adresse1 = elements[4],
                    Adresse2 = elements[5],
                    Ville = elements[6],
                    Province = elements[7],
                    Pays = elements[8],
                    CodeP = elements[9],

                });
                    
                
            }
        }
    }
}
