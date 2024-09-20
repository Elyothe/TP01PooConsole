using System;
using System.Collections.Generic;
using System.Linq;
using Test.Interfaces;

namespace Test
{
    public class User : Bibliothéque, IUser
    {
        public string NomUser { get; set; }
        public string Prenom { get; set; }
        public int UserId { get; set; }
        public List<Livre> LesLivresEmpruntes { get; set; } = new List<Livre>();
        public int Credit { get; set; }

        public virtual int MaxLivresEmpruntables => 3;

        public User(string nomBib, string nomUser, string prenom, int userId, int uncre) : base(nomBib)
        {
            Nom = nomUser;
            Prenom = prenom;
            UserId = userId;
            Credit = uncre;
        }

        public static List<IUser> InitListUser()
        {
            int CreditBasic = 3;
            int CreditVIP = 5;

            string nomBib = "Municipale";
            return new List<IUser>
            {
                new User(nomBib, "James", "Antoine", 12,CreditBasic ),
                new User(nomBib, "Kevin", "Diesel", 123, CreditBasic),
                new User(nomBib, "Thomas", "Orwell", 1234, CreditBasic),
                new User(nomBib, "Baptiste", "Camus", 12345, CreditBasic),
        
                // Ajout des utilisateurs VIP
                new UserVIP(nomBib, "Esteban", "Torres", 23456, CreditVIP),
                new UserVIP(nomBib, "Marie", "Curie", 23457, CreditVIP),
                new UserVIP(nomBib, "Albert", "Einstein", 23458, CreditVIP)
            };
        }

        public void ShowLstUser(List<IUser> lesUsers)
        {
            foreach (IUser item in lesUsers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void AddUser(List<IUser> lesUsers)
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            int id = new Random().Next(1, 101);
            int credit = 3;
            string nomBib = "Municipale";

            IUser nouveauUser = new User(nomBib, nom, prenom, id, credit);
            lesUsers.Add(nouveauUser);
            Console.WriteLine("\nListe des Users après ajout :");
        }

        public void DeleteUser(List<IUser> lesUsers)
        {
            ShowLstUser(lesUsers);
            Console.WriteLine("Saisissez l'Id de l'utilisateur à supprimer :");
            int idUser = int.Parse(Console.ReadLine());
            IUser userASupprimer = lesUsers.FirstOrDefault(user => user.UserId == idUser);

            if (userASupprimer != null)
            {
                lesUsers.Remove(userASupprimer);
                Console.WriteLine("L'utilisateur a été supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Aucun utilisateur trouvé avec cet ID.");
            }
        }

        public void EmprunterLivre(List<Livre> lesLivres, List<IUser> lesUsers)
        {
            Console.WriteLine("Sélectionnez un utilisateur à qui ajouter un livre :");
            foreach (var utilisateur in lesUsers)
            {
                Console.WriteLine(utilisateur.ToString());
            }

            Console.WriteLine("Saisissez l'ID de l'utilisateur :");
            int idUser = int.Parse(Console.ReadLine());

            var utilisateurSelectionne = lesUsers.FirstOrDefault(user => user.UserId == idUser);

            if (utilisateurSelectionne == null)
            {
                Console.WriteLine("Utilisateur non trouvé.");
                return;
            }

            Console.WriteLine("Saisissez l'ISBN du livre à emprunter :");
            int livreEmprunt = int.Parse(Console.ReadLine());

            var livreTrouve = lesLivres.FirstOrDefault(livre => livre.ISBN == livreEmprunt);

            if (livreTrouve != null && utilisateurSelectionne.Credit >0)
            {
                Emprunt NouvelEmprunt = new Emprunt(livreTrouve, utilisateurSelectionne);
                utilisateurSelectionne.LesLivresEmpruntes.Add(livreTrouve);
                lesLivres.Remove(livreTrouve);
                
                utilisateurSelectionne.Credit--;
                Console.WriteLine($"{utilisateurSelectionne.Nom} a emprunté {livreTrouve.titre}. A rendre le {NouvelEmprunt.DateFinPrevue}{utilisateurSelectionne.Credit} crédits.");
            }
            else if (utilisateurSelectionne.Credit <= MaxLivresEmpruntables)
            {
                Console.WriteLine("Cet utilisateur n'a plus de crédits disponibles pour emprunter un livre.");
            }
            else
            {
                Console.WriteLine("Livre non trouvé.");
            }
        }


        public void RetournerLivre(List<Livre> lesLivres, List<IUser> lesUsers)
        {
            Console.WriteLine("Sélectionnez un utilisateur à qui retourner un livre :");
            ShowLstUser(lesUsers);

            Console.WriteLine("Saisissez l'ID de l'utilisateur :");
            int idUser = int.Parse(Console.ReadLine());

            var utilisateur = lesUsers.FirstOrDefault(user => user.UserId == idUser);

            if (utilisateur == null)
            {
                Console.WriteLine("Utilisateur non trouvé.");
                return;
            }

            Console.WriteLine("Saisissez l'ISBN du livre à rendre :");
            int livreEmprunt = int.Parse(Console.ReadLine());

            var livreTrouve = utilisateur.LesLivresEmpruntes.FirstOrDefault(livre => livre.ISBN == livreEmprunt);

            if (livreTrouve != null)
            {
                utilisateur.LesLivresEmpruntes.Remove(livreTrouve);
                lesLivres.Add(livreTrouve);
                utilisateur.Credit++;
                Console.WriteLine($"{utilisateur.Nom} a rendu {livreTrouve.titre}. Il lui reste {utilisateur.Credit} crédits.");
            }
            else
            {
                Console.WriteLine("Livre non trouvé.");
            }
        }

        public override string ToString()
        {
            return $"Nom: {Nom}, Prénom: {Prenom}, ID: {UserId}, Crédits restants: {Credit}";
        }
    }
}
        