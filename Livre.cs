using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Interfaces;

namespace Test
{
    public class Livre : Bibliothéque
    {
        public string titre;
        public int ISBN;
        public string auteur;
        public int DatePub;
        public Livre(string unnom, string untitre, int unISBN, string unauteur, int UneDatePub)
            : base(unnom)
        {
            titre = untitre;
            ISBN = unISBN;
            auteur = unauteur;
            DatePub = UneDatePub;
         }
        public string getitre()
        {
            return titre;
        }

        public int getISBN()
        {
            return ISBN;
        }
        public string getauteur()
        {
            return auteur;
        }
        public int getDatePub()
        {
            return DatePub;
        }
        public void settitre(string titre)
        {
            this.titre = titre;
        }

        public void setAuteur(string auteur)
        {
            this.auteur = auteur;
        }
        public void setISBN(int iSBN)
        {
            this.ISBN = iSBN;
        }

        public override string ToString()
        {
            return $"Titre: {titre}, ISBN: {ISBN}, Auteur: {auteur}, Date de publication: {DatePub}";
        }

        public static List<Livre> InitList()
        {
            string nomBib = "Municipale";
            List<Livre> leslivres = new List<Livre>
            {
                new Livre(nomBib,"Le Petit Prince",12, "Antoine de Saint-Exupéry", 1943),
                new Livre(nomBib,"Les Misérables",123, "Victor Hugo", 1862),
                new Livre(nomBib,"1984",1234, "George Orwell", 1949),
                new Livre(nomBib, "L'Étranger",12345, "Albert Camus", 1942)
            };

            return leslivres; 
        }

        public void ShowLst(List<Livre> leslivres)
        {
            foreach(Livre item in leslivres)
            {
                Console.WriteLine(item.ToString());
            }
            
        }
        public void AddLivre(List<Livre> leslivres)
        {
            Console.WriteLine("Titre");
            string Titre = Console.ReadLine();
            Console.WriteLine("Auteur");
            string Auteur = Console.ReadLine();
            Console.WriteLine("ISBN");
            int ISBN = int.Parse(Console.ReadLine());
            Console.WriteLine("Annee");
            int annee = int.Parse(Console.ReadLine());
            string nomBib = "Municipale";
            Livre NewLivre = new Livre(nomBib,Titre, ISBN,Auteur, annee);
            leslivres.Add(NewLivre);
            Console.WriteLine("\nListe des livres après ajout :");

        }

        public void DeleteLivre(List<Livre> leslivres)
        {
            ShowLst(leslivres);
            Console.WriteLine("Saisissez l'ISBN du livre à supprimer :");
            int IdBook = int.Parse(Console.ReadLine());
            Livre livreASupprimer = leslivres.FirstOrDefault(livre => livre.getISBN() == IdBook);

            if (livreASupprimer != null)
            {
                leslivres.Remove(livreASupprimer);
                Console.WriteLine("Le livre a été supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Aucun livre trouvé avec cet ISBN.");
            }
        }
    }
}



