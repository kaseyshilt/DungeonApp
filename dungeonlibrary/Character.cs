using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
        abstract class Character
    {
        //fields
        private int _life;

        //props
        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {
                if (value <= MaxLife)
                {
                    _life = value;
                }//end if

                else
                {
                    _life = MaxLife;
                }//end else

            }//end set
        }//end life

        //ctors

        //methods
        public virtual int CalcBlock()
        {
            return Block;
        }//end calcblock()

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end clachitchance()

        public virtual int CalcDamage()
        {
            return 0;
        }//end calcdamage

    }//end class
}//end namespace
