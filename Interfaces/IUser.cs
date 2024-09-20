using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Interfaces
{
    public interface IUser
    {
        string Nom { get; set; }
        string Prenom { get; set; }
        int UserId { get; set; }
        int Credit { get; set; }
        List<Livre> LesLivresEmpruntes { get; set; }

        int MaxLivresEmpruntables { get; }

        void AddUser(List<IUser> lesUsers);
        void ShowLstUser(List<IUser> lesUsers);
        void EmprunterLivre(List<Livre> lesLivres, List<IUser>lesUsers);
        void RetournerLivre(List<Livre> lesLivres, List<IUser>leUsers);
    }
}
