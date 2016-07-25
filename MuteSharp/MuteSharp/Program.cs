using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;
using System.Reflection;
using Color = SharpDX.Color;
using System.Linq;

namespace MuteSharp
{
    class Program
    {

        public static Menu Menu;

        static void Main(string[] args)
        {

            CustomEvents.Game.OnGameLoad += Load;

        }

        static void Load(EventArgs args)
        {

            Menu = new Menu(" :: MuteSharp :^)", "bmsharpmenu", true).SetFontStyle(FontStyle.Regular, Color.Red);
            Menu.AddItem(new MenuItem("by.Art3mis", "Another assembly from your one and only god - Art3mis.").SetFontStyle(FontStyle.Regular, Color.White));
            Menu.AddItem(new MenuItem("toggleTeam", "Mute Team?").SetValue(true).SetFontStyle(FontStyle.Regular, Color.Green));
            Menu.AddItem(new MenuItem("toggleEnemy", "Mute Enemy?").SetValue(true).SetFontStyle(FontStyle.Regular, Color.Red));
            Menu.AddItem(new MenuItem("seperator", ""));
            Menu.AddItem(new MenuItem("info", "Upd. Patch 6.14 - Build 24.7.2016").SetFontStyle(FontStyle.Regular, Color.White));
            Menu.AddToMainMenu();

            if (Menu.Item("toggleTeam").GetValue<bool>())
            {
                muteTeam();
            }

            if (Menu.Item("toggleEnemy").GetValue<bool>())
            {
                muteEnemy();
            }

        }

        public static void muteTeam()
        {
            var mode = Menu.Item("toggleTeam").GetValue<bool>();
            if (mode == false) return;
            Game.Say("/mute team");
            Game.PrintChat("Ally team muted.");
        }

        public static void muteEnemy()
        {
            var mode = Menu.Item("toggleEnemy").GetValue<bool>();
            if (mode == false) return;
            Game.Say("/mute enemy");
            Game.PrintChat("Enemy team muted.");
        }

    }
}
