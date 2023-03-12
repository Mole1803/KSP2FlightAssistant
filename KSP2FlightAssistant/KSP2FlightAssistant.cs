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
        
        // BepInEx Log
        internal static new ManualLogSource Log;
        
        // Game
        static GameInstance Game => GameManager.Instance == null ? null : GameManager.Instance.Game;
        private Rect _window = new Rect(0, 0, 300, 300);
        private bool test_button, test_toggle, test_toggle_before;
        
        private float updateInterval = 0.125f;
        private float lastUpdate = 0;

        public override void OnInitialized()
        {
            base.OnInitialized();
            Instance = this;
        }
        
        public void OnGUI()
        {
            GUI.skin = Skins.ConsoleSkin;
            GUILayout.Height(300);
            GUILayout.Width(300);
            _window = GUILayout.Window(GUIUtility.GetControlID(FocusType.Passive), _window, DrawUI, "KSP2FlightAssistant");
            
        }
        
        private void DrawUI(int windowID)
        {
            GUILayout.BeginVertical();
            GUILayout.Label("KSP2FlightAssistant");
            GUILayout.EndVertical();
            
            GUILayout.BeginVertical();
            test_button = GUILayout.Button("Test"); 
            test_toggle = GUILayout.Toggle(!test_toggle, "Toggle");
            GUILayout.EndVertical();

            GUI.DragWindow();
        }

        private void LateUpdate()
        {
            if (Time.time - lastUpdate < updateInterval)
            {
                return;
            }

            lastUpdate = Time.time;
            
            

            if (Game.GlobalGameState.GetState() == KSP.Game.GameState.FlightView ||
                Game.GlobalGameState.GetState() == KSP.Game.GameState.Map3DView)
            {

                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.ManeuverMarkerVector.GetValue().x);
                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.ManeuverMarkerVector.GetValue().y);
                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.ManeuverMarkerVector.GetValue().z);
                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.NAVBallRotation.GetValue().x);
                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.NAVBallRotation.GetValue().y);
                Logger.LogInfo(Game.ViewController.DataProvider.TelemetryDataProvider.NAVBallRotation.GetValue().z);
                Logger.LogInfo("----");

                KSPVessel kspVessel = new KSPVessel(Game);
                if (kspVessel.GetDisplaySpeed() > 15)
                {
                    // Example of how to maneuver the vessel
                    /*kspVessel.StartControlInstruction();
                    //kspVessel.SetThrottle(0.5f);
                    kspVessel.SetRollTrim(0.5f);
                    kspVessel.ExecuteControlInstruction();*/

                    //Logger.LogInfo(kspVessel.GetDisplayAltitude());

                }
            }



        }
    }

}