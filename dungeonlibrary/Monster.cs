using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
    public class Monster : Character
    {
        
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value > 0 && value <= MaxDamage)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    _minDamage = 1;
                }//end else
            }//end set
        }//end mindamage

        public Monster() { }
        public Monster(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description)
        {
            MaxLife = maxLife;
            MaxDamage = maxDamage;
            Name = name;
            Life = life;
            HitChance = hitChance;
            Block = block;
            MinDamage = MinDamage;
            Description = description;
        }//end FQCTOR

        //methods
        public override string ToString()
        {
            return string.Format("\n-=-= MONSTER =-=-\n" +
                "{0}\n" +
                "Life: {1} of {2}\n" +
                "Damage: {3} of {4}\n" +
                "Block: {5}\n" +
                "Description:\n" +
                "{6}",
                Name, Life, MaxLife, MinDamage, MaxDamage, Block, Description);
        }//end tostring


        public override int CalcDamage()
        {
            Random rand = new Random();
            return rand.Next(MinDamage, MaxDamage + 1);
        }//end calcdamage
    }
}
