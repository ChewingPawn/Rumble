using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace Rumble
{
    class MenuHandler
    {
        public static void Combo()
        {
            Menu menu = MenuHandler.Combo;
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
        public static void JunglerClear()
        { 
            Menu menu = MenuHandler.JunglerClear;
            List<Obj_AI_Base> enemies = EntityManager.MinionsAndMonsters.Monsters.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);

            if (menu.GetCheckboxValue("Use E") && bestEPos.HitNumber >= 1)
                CastE(bestEPos.CastPosition);
        }
        public static void LastHit()
        {
            Menu menu = MenuHandler.LastHit;
            List<Obj_AI_Base> enemies = EntityManager.MinionsAndMonsters.Monsters.ToList().ToObj_AI_BaseList();
            Spell.Skillshot.BestPosition bestEPos = Program.E.GetBestLinearCastPosition(enemies);
        }
    public static void CastE(Vector3 pos)
        {
            if (Program.E.IsReady() && pos != Vector3.Zero)
                Program.E.Cast(pos);
        }

        //preping menus for use
        public static Menu mainMenu, Combo, Harass, AutoHarass, LastHit, LaneClear, JungleClear, Misc, Drawing;

        //initializes menu
        public static void Initialize()
        {
            //creates the primary menu. This menu is assigned globally above.
            mainMenu = MainMenu.AddMenu("Rumble", "Main Menu");

            //creates menus below the primary one. These menus are assigned globally above.
            Combo = AddSubMenu(mainMenu, "Combo");
            Harass = AddSubMenu(mainMenu, "Harass");
            AutoHarass = AddSubMenu(mainMenu, "Auto Harass");
            LaneClear = AddSubMenu(mainMenu, "Lane Clear");
            JungleClear = AddSubMenu(mainMenu, "Jungle Clear");
            LastHit = AddSubMenu(mainMenu, "Last Hit");
            Misc = AddSubMenu(mainMenu, "Misc");
            Drawing = AddSubMenu(mainMenu, "Drawing");

            //adding checkboxs to the menu Combo. Putting _false at the end sets the default value to false.
            AddCheckboxes(ref Combo, "Use Q", "Use W_false", "Use E", "Use R", "Use Ignite");
            //adds a slider to the Combo menu.
            AddSlider(Combo, "Enemies in range for R", 2, 1, 5);

            //adds checkboxes to the rest of the menus.
            AddCheckboxes(ref Harass, "Use Q", "Use E");
            AddCheckboxes(ref AutoHarass, "Use Q", "Use E");
            AddCheckboxes(ref LastHit, "Use E");
            AddCheckboxes(ref LaneClear, "Use Q", "Use E");
            AddCheckboxes(ref JungleClear, "Use Q", "Use E");
            AddCheckboxes(ref Drawing, "Enable Drawing", "Draw Q", "Draw E", "Draw R", "Draw Damage after E", "Draw Damage on Enemy Health");
            
            Console.WriteLine("Menu Loaded");
        }

        //method to add checkboxes
        public static void AddCheckboxes(ref Menu menu, params string[] checkBoxValues)
        {
            foreach (string s in checkBoxValues)
            {
                if (s.Length > "_false".Length && s.Contains("_false"))
                    AddCheckbox(ref menu, s.Remove(s.IndexOf("_false"), 6), false);
                else
                    AddCheckbox(ref menu, s, true);
            }
        }
        //method to add sub menu
        public static Menu AddSubMenu(Menu startingMenu, string text)
        {
            Menu menu = startingMenu.AddSubMenu(text, text + ".");
            menu.AddGroupLabel(text + " Settings");
            return menu;
        }
        //method to add checkbox
        public static CheckBox AddCheckbox(ref Menu menu, string text, bool defaultValue = true)
        {
            return menu.Add(menu.UniqueMenuId + text, new CheckBox(text, defaultValue));
        }
        //method to get checkbox
        public static CheckBox GetCheckbox(Menu menu, string text)
        {
            return menu.Get<CheckBox>(menu.UniqueMenuId + text);
        }
        //method to get checkbox value
        public static bool GetCheckboxValue(Menu menu, string text)
        {
            CheckBox checkbox = GetCheckbox(menu, text);

            if (checkbox == null)
                Console.WriteLine("Checkbox (" + text + ") not found under menu (" + menu.DisplayName + "). Unique ID (" + menu.UniqueMenuId + text + ")");

            return checkbox.CurrentValue;
        }
        //method to add combobox
        public static ComboBox AddComboBox(Menu menu, string text, int defaultValue = 0, params string[] values)
        {
            return menu.Add(menu.UniqueMenuId + text, new ComboBox(text, defaultValue, values));
        }
        //method to get combobox value
        public static ComboBox GetComboBox(Menu menu, string text)
        {
            return menu.Get<ComboBox>(menu.UniqueMenuId + text);
        }
        //method to get combobox text
        public static string GetComboBoxText(Menu menu, string text)
        {
            return menu.Get<ComboBox>(menu.UniqueMenuId + text).SelectedText;
        }
        //method to get slider
        public static Slider GetSlider(Menu menu, string text)
        {
            return menu.Get<Slider>(menu.UniqueMenuId + text);
        }
        //method to get slider value
        public static int GetSliderValue(Menu menu, string text)
        {
            return menu.Get<Slider>(menu.UniqueMenuId + text).CurrentValue;
        }
        //method to add slider
        public static Slider AddSlider(Menu menu, string text, int defaultValue, int minimumValue, int maximumValue)
        {
            return menu.Add(menu.UniqueMenuId + text, new Slider(text, defaultValue, minimumValue, maximumValue));
        }
    }
}

