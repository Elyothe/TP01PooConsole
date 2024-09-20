using System;
using System.Collections.Generic;
using Test.Interfaces;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaration list et objet Livre
            List<Livre> listeDeLivres = Livre.InitList();
            Livre livre = new Livre("Municipale", "Titre de test", 0, "Auteur de test", 2023);

            //Declaration List et objet User
            List<IUser> listeDeUsers = User.InitListUser();
            User user = new User("Municipale", "Jean", "Michel", 123,5);

            ConsoleKeyInfo key;
    
            Console.WriteLine("                      ================================================");
            Console.WriteLine("                      |              MENU PRINCIPAL                  |");
            Console.WriteLine("                      ================================================");
            Console.WriteLine("                      |                                              |");
            Console.WriteLine("                      |           1. Ajouter un livre                |");
            Console.WriteLine("                      |           2. Ajouter un utilisateur          |");
            Console.WriteLine("                      |           3. Liste des utilisateurs          |");
            Console.WriteLine("                      |           4. Liste des livres                |");
            Console.WriteLine("                      |           5. Supprimer un livre              |");
            Console.WriteLine("                      |           6. Supprimer un utilisateur        |");
            Console.WriteLine("                      |           7. Emprunter un livre              |");
            Console.WriteLine("                      |           8. Retourner un livre              |");
            Console.WriteLine("                      |                                              |");
            Console.WriteLine("                      ================================================");






            while (true)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.R:
                        break;
                    case ConsoleKey.D1:
                        
                        livre.AddLivre(listeDeLivres);
                        livre.ShowLst(listeDeLivres);

                        break;

                    case ConsoleKey.D2:

                        user.AddUser(listeDeUsers);
                        user.ShowLstUser(listeDeUsers);

                        break;

                    case ConsoleKey.D3:

                        user.ShowLstUser(listeDeUsers);
                        break;

                    case ConsoleKey.D4:

                        livre.ShowLst(listeDeLivres);
                        break;

                    case ConsoleKey.D5:

                        livre.DeleteLivre(listeDeLivres);
                        break;

                    case ConsoleKey.D6:
                        user.DeleteUser(listeDeUsers);
                        break;

                    case ConsoleKey.D7:
                        user.EmprunterLivre(listeDeLivres,listeDeUsers);
                        break;

                    case ConsoleKey.D8:
                        user.RetournerLivre(listeDeLivres,listeDeUsers);
                        break;

                    default:
                        break;
                }
            }
        }           
      }
    }
