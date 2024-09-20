using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Interfaces;

namespace Test
{
    internal class UserVIP : User, IUser
    {
        public int PointsFidelite { get; set; }

        public override int MaxLivresEmpruntables => 5;


        public UserVIP(string nomBib,string nom, string prenom, int unId,int uncre)
           : base(nomBib,nom, prenom, unId,uncre)
        {
            
        }


    }
}
