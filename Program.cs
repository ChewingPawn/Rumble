+using System;
 +using EloBuddy;
 +using EloBuddy.SDK;
 +using EloBuddy.SDK.Events;
 +using EloBuddy.SDK.Menu;
 +using EloBuddy.SDK.Menu.Values;
 +using System.Collections.Generic;
 +using EloBuddy.SDK.Enumerations;
 +
 +namespace Rumble
 +{
 +    internal class Program
 +    {
 +        public static Spell.Active Q, W;
 +        public static Spell.Skillshot E, R;
 +        public static Spell.Targeted Ignite;
 +        public static AIHeroClient Rumble => Player.Instance;
 +        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName != "Rumble")
                return;

        private static void Loading_OnLoadingComplete(EventArgs args)
        {

 +            #region Initializers
 +            MenuHandler.Initialize();
 +            #endregion
 +
 +            //setup methods
 +            Game.OnTick += Game_OnTick;
 +            Drawing.OnDraw += Drawing_OnDraw;

            //setup methods
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
        }
              #region SpellSetup
              Q = new Spell.Active(SpellSlot.Q);
              W = new Spell.Active(SpellSlot.W);
              E = new Spell.Skillshot(SpellSlot.E, 850, SkillShotType.Linear, 250, 2000, 60, DamageType.Magical);
 +            R = new Spell.Skillshot(SpellSlot.R, 1700, SkillShotType.Linear, 250, int.MaxValue, 200, DamageType.Magical);
 +            Ignite = new Spell.Targeted(Rumble.GetSpellSlotFromName("SummonerDot"), 600, DamageType.True)
              {
                   CastDelay = 0,
 +            };
              #endregion
        
        +        }
 +        
 +        //this method is called every time the drawing resets.
 +        //this is the only place you can have drawings.
 +        private static void Drawing_OnDraw(EventArgs args)
          }
 +
 +        //this method is called every time the game processes a tick
 +        private static void Game_OnTick(EventArgs args)
 +        {
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
        }
    }
}
        {

        }
    }
}