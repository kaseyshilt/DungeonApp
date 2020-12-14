using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dungeonlibrary
{
    public sealed class Player : Character
    {

        //fields

        //props
        public Race CharacterRace { get; set; }
        public Weapon EquippedWeapon { get; set; }



        //ctors
        public Player(string name, int hitChance, int block, int life, int maxLife, Race characterRace, Weapon equippedWeapon)
        {
            MaxLife = maxLife;
            Name = name;
            Block = block;
            Life = life;
            CharacterRace = characterRace;
            EquippedWeapon = equippedWeapon;
            HitChance = hitChance;
        }//end fqctor

        //methods 
        public override string ToString()
        {
            return string.Format("-=-= {0} =-=-\n" +
                "Life: {1} of {2}\n" +
                "Weapon: {3}\n" +
                "Hit Chance: {4}\n" +
                "Block: {5}\n" +
                "Description: {6}\n",
                Name, Life, MaxLife, EquippedWeapon, CalcHitChance(), Block, CharacterRace);
        }//end tostring()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }//end calcdamage()

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedWeapon.BonusHitChance;
        }


    }//end class
}//end namespace
