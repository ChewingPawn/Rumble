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
        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            //initalize the menu
            MenuHandler.Initialize();
            
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

        }
    }
}