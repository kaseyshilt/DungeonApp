using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
    public class GodZilla : Monster
    {
        //fields
        //n/a

        //props
        public bool IsScaly { get; set; }


        //ctors
        public GodZilla(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, bool isScaly) : base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            IsScaly = isScaly;
        }

        public GodZilla()
        {
            MaxLife = 100;
            MaxDamage = 50;
            Name = "GodZilla";
            Life = 100;
            HitChance = 25;
            Block = 80;
            MinDamage = 10;
            Description = "Run!!! It is GODZILLA!!!!!!";
            IsScaly = true;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return base.ToString() + (IsScaly ? "It has thick scales" : "Not so well armored");
        }//end tostring

        public override int CalcBlock()
        {
            int calculatedBlock = Block;
            if (IsScaly)
            {
                calculatedBlock += calculatedBlock / 4;
            }

            return calculatedBlock;
        }

    }//end class
}//end namespace
