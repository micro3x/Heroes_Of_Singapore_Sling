using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssets.Interfaces
{
    public interface IFightable
    {


        int DefenceRating { get; }
        int AttackRating
        {
            get;
        }
        int AttackSpeed
        {
            get;
        }
        int Healt
        {
            get;
            set;
        }

        int Defence
        {
            get;
        }



        int MakeDamage();



    }
}
