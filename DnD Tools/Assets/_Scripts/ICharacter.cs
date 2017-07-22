using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface ICharacter
    {
        int MovementSpeed { get; set; }
        int AttackDamage { get; set; }
        int AttackRange { get; set; }
        int ClimbingFactor { get; set; }
        int Level { get; set; }
        String name { get; set; }
        String tag { get; set; }
        

        void takeDamage(ICharacter other);
        
    }
}
