using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System.Collections.Generic;

namespace SmebRumble
{
    internal class Program
    {
        public static Spell.Active Q, W;
        public static Spell.Skillshot E, R;
        public static AIHeroClient Rumble => Player.Instance;
        public static string Animation = "";
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Rumble")
                return;

            #region SpellSetup
            Q = new Spell.Active(SpellSlot.Q);
            W = new Spell.Active(SpellSlot.W);
            E = new Spell.Skillshot(SpellSlot.E, 850f, SkillShotType.Linear, 250, 2000, 60, DamageType.Magic)
            R = new Spell.Skillshot(SpellSlot.R, 1700, SkillShotType.Linear, 250, int.MaxValue, 200, DamageType.Magic)
            {
                Ignite = new Spell.Targeted(Rumble.GetSpellSlotFromName("SummonerDot"), 600, DamageType.True)
            {
                CastDelay = 0,
                #endregion
        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //initalize the menu
            #region Initializers
            MenuHandler.Initialize();
            #endregion

            //setup methods
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }
        
        //this method is called every time the drawing resets.
        //this is the only place you can have drawings.
        private static void Drawing_OnDraw(EventArgs args)
        {

        }

        //this method is called every time the game processes a tick
        private static void Game_OnTick(EventArgs args)
        {
            ModeHandler.hasDoneActionThisTick = false;

            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                ModeHandler.Combo();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                ModeHandler.JungleClear();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit))
                ModeHandler.LastHit();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                ModeHandler.LaneClear();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                ModeHandler.Harass();
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee))
                ModeHandler.Flee();
            if (MenuHandler.Killsteal.GetCheckboxValue("Killsteal"))
                ModeHandler.Killsteal();
        }
    }
}
        {

        }
    }
}