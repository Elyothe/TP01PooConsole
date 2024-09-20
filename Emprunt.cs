using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Interfaces;

namespace Test
{
    public class Emprunt
    {
        public Livre LivreEmprunte { get; set; }
        public IUser Utilisateur { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFinPrevue { get; set; }

        public Emprunt (Livre livre, IUser utilisateur)
        {
            LivreEmprunte = livre;
            Utilisateur = utilisateur;
            DateDebut = DateTime.Now;
            DateFinPrevue = DateDebut.AddDays(30);
        }
        public override string ToString()
        {
            return $"Livre: {LivreEmprunte.titre}, Emprunté par: {Utilisateur.Nom}, Date début: {DateDebut}, Date fin prévue: {DateFinPrevue}";
        }
    }
}

