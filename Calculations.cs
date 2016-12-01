using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using SharpDX;


namespace Rumble
{
    class Calculations
    {
        public static AIHeroClient Rumble => Player.Instance;

        public static float Q(Obj_AI_Base target)
        {
            //this is j4s q info
            float dmg = 25 + 45 * Program.Q.Level;
            dmg += 1.2f * (Rumble.TotalAttackDamage - Rumble.BaseAttackDamage);

            if (target.Type == GameObjectType.AIHeroClient)
                dmg *= 1.33f;

            return Rumble.CalculateDamageOnUnit(target, DamageType.Physical, dmg);
        }
        public static float W(Obj_AI_Base target)
        {
            float dmg = 0;

            return Rumble.CalculateDamageOnUnit(target, DamageType.Physical, dmg);
        }
        public static float E(Obj_AI_Base target)
        {
            //this is j4s e info
            return Rumble.CalculateDamageOnUnit(target, DamageType.Physical,
                15 + 45 * Program.E.Level
                + (Rumble.TotalMagicalDamage * 0.8f));
        }
        public static float R(Obj_AI_Base target)
        {
            //this is j4s r info
            float dmg = 75 + 125 * Program.R.Level;
            dmg += 1.5f * (Rumble.TotalAttackDamage - Rumble.BaseAttackDamage);
            return Rumble.CalculateDamageOnUnit(target, DamageType.Physical, dmg);
        }
        public static float Ignite(Obj_AI_Base target)
        {
            return ((10 + (4 * Rumble.Level)) * 5) - ((target.HPRegenRate / 2) * 5);
        }
        public static float Smite()
        {
            return new int[] { 0, 390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000 }[Rumble.Level];
        }
    }
}
