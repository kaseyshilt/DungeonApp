using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dungeonlibrary;

namespace dungeonlibrary
{
    public class Weapon
    {
        //fields
        private int _minDamage;
        private int _maxDamage;
        private string _name;
        private int _bonusHitChance;
        private bool _isTwoHanded;



        //properties 
        public int MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//end max dmg

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end name

        public int BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }

        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }

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
                }
            }//end set
        }//end mindamage

        //constructors
        public Weapon(int minDamage, int maxDamage, string name, int bonusHitChance, bool isTwoHanded)
        {
        
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwoHanded = isTwoHanded;
        }


        //methods
        public override string ToString()
        {
            return string.Format("{0}\t{1} to {2} Damage\n" + "Bonus hit chance: {3}%\t{4}\n\n",
                Name, MinDamage, MaxDamage, BonusHitChance,
                IsTwoHanded ? "Two-Handed" : "One-Handed");
        }//end tostring()
    }//end class
}//end namespace
