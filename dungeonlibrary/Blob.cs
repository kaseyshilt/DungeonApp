using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
    
    public class Blob : Monster
    {
        //fields

        //props
        public bool IsBeefy { get; set; }

        //ctor - 
        public Blob(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isBeefy) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsBeefy = isBeefy;
        }//end FQCTOR

        public Blob()
        {
            MaxLife = 50;
            MaxDamage = 5;
            Name = "King Blob";
            Life = 20;
            HitChance = 20;
            Block = 30;
            MinDamage = 1;
            Description = "Will not only eat all the food you can think of, but it will eat you too if you are not careful!";
            IsBeefy = true;
        }//end default ctor

        //methods 

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            if (IsBeefy)
            {
                calculatedBlock += calculatedBlock / 2;
            }

            return calculatedBlock;
        }
    }
}
