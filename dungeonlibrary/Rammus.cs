using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
    public class Rammus : Monster
    {
        //fields

        //props
        public int BonusBlock { get; set; }
        public int HidePercent { get; set; }

        //ctor
        public Rammus(string name, int life, int maxLife, int hitChance, int block, int minDamage, int maxDamage, string description, int bonusBlock, int hidePercent) :base(name, life, maxLife, hitChance, block, minDamage, maxDamage, description)
        {
            BonusBlock = bonusBlock;
            HidePercent = hidePercent;
        }//end fqctor

        public Rammus()
        {
            MaxLife = 80;
            MaxDamage = 5;
            Life = 60;
            MinDamage = 1;
            HitChance = 20;
            Block = 40;
            Name = "Rammus";
            Description = "Oh no! It is the tankiest creature of the Dungeon Born Family!";
            BonusBlock = 15;
            HidePercent = 10;
        }//end default ctor

        //methods
        public override string ToString()
        {
            return string.Format("{0}\nChance it'll hide: {1}% and then it has a bonus block of {2}", base.ToString(), HidePercent, BonusBlock);
        }//end tostring()

        public override int CalcBlock()
        {
            int calculatedBlock = Block;

            Random rand = new Random();
            int percent = rand.Next(101);

            if (percent <= HidePercent)
            {
                calculatedBlock += BonusBlock;
            }


            return calculatedBlock;
        }
    }
}
