using System;
using System.Collections.Generic;

namespace Test
{
    public class Bibliothéque
    {
        public string Nom { get; set; }
        public List<Livre> Livres { get; set; } 
        public List<User> User { get; set; } 

        public Bibliothéque(string unnom)
        {
            Nom = unnom;
            Livres = new List<Livre>(); 
            User = new List<User>(); 
        }

        // Méthode pour ajouter un livre à la bibliothèque
        public void AjouterLivre(Livre livre)
        {
            Livres.Add(livre);
        }

        // Méthode pour ajouter un utilisateur à la bibliothèque
        public void AjouterUtilisateur(User utilisateur)
        {
            User.Add(utilisateur);
        }

        // Méthode pour afficher tous les livres
        public void AfficherLivres()
        {
            Console.WriteLine("Livres dans la bibliothèque :");
            foreach (var livre in Livres)
            {
                Console.WriteLine(livre.ToString());
            }
        }

        // Méthode pour afficher tous les utilisateurs
        public void AfficherUtilisateurs()
        {
            Console.WriteLine("Utilisateurs de la bibliothèque :");
            foreach (var utilisateur in User)
            {
                Console.WriteLine(utilisateur.ToString());
            }
        }
    }
      
}
