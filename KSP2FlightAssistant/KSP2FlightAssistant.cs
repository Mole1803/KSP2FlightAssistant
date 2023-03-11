using System;
using KSP;
using KSP.Game;
using UnityEngine;
using BepInEx;
using BepInEx.Logging;
using SpaceWarp.API.Mods;
using SpaceWarp;
using SpaceWarp.API.UI;


namespace KSP2FlightAssistant
{
    [BepInDependency(SpaceWarpPlugin.ModGuid, SpaceWarpPlugin.ModVer)]
    [BepInPlugin(ModGuid, ModName, ModVer)]
    public class KSP2FlightAssistant : BaseSpaceWarpPlugin
    {
        // Mod info
        public const string ModGuid = "com.github.Mole1803.KSP2FlightAssistant";
        public const string ModName = "KSP2FlightAssistant";
        public const string ModVer = "1.0.0";
        private static KSP2FlightAssistant Instance { get; set; }

        public override void OnInitialized()
        {
            base.OnInitialized();
            Instance = this;
        }
    }

}