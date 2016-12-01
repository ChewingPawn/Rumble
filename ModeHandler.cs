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
    class ModeHandler
    {
        public static void Combo()
        {
            Menu menu = MenuHandler.Combo;
            List<Obj_AI_Base> enemies = EntityManager.Heroes.Enemies.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);

            if (menu.GetCheckboxValue("Use E") && bestEPos.HitNumber >= 1)
                CastE(bestEPos.CastPosition);
        }
        public static void Harass()
        {
            Menu menu = MenuHandler.Harass;
            List<Obj_AI_Base> enemies = EntityManager.Heroes.Enemies.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);

            if (menu.GetCheckboxValue("Use E") && bestEPos.HitNumber >= 1)
                CastE(bestEPos.CastPosition);
        }
        public static void LaneClear()
        {
            Menu menu = MenuHandler.LaneClear;
            List<Obj_AI_Base> enemies = EntityManager.MinionsAndMonsters.EnemyMinions.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);

            if (menu.GetCheckboxValue("Use E") && bestEPos.HitNumber >= 1)
                CastE(bestEPos.CastPosition);
        }
        public static void JungleClear()
        {
            Menu menu = MenuHandler.JungleClear;
            List<Obj_AI_Base> enemies = EntityManager.MinionsAndMonsters.Monsters.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);

            if (menu.GetCheckboxValue("Use E") && bestEPos.HitNumber >= 1)
                CastE(bestEPos.CastPosition);
        }
        public static void LastHit()
        {
            Menu menu = MenuHandler.LastHit;
            List<Obj_AI_Base> enemies = EntityManager.MinionsAndMonsters.EnemyMinions.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);
        }
        public static void CastE(Vector3 pos)
        {
            if (Program.E.IsReady() && pos != Vector3.Zero)
                Program.E.Cast(pos);
        }
    }
}
