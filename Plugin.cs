using BepInEx;
using KSP.Game;
using UnityEngine;
using BepInEx.Logging;

namespace KSP2FlightAssistant
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Log;
        static GameInstance Game => GameManager.Instance == null ? null : GameManager.Instance.Game;
        
        private float updateInterval = 0.125f;
        private float lastUpdate = 0;
        private bool set_vessel = false;
        




        private void Awake()
        {
            // Initialize logger from BepInEx
            Log = base.Logger;
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void LateUpdate()
        {
            if (Time.time - lastUpdate < updateInterval)
            {
                return;
            }
            
            lastUpdate = Time.time;

            if (Game.GlobalGameState.GetState() == KSP.Game.GameState.FlightView || Game.GlobalGameState.GetState() == KSP.Game.GameState.Map3DView)
            {
                

                
                KSPVessel kspVessel = new KSPVessel(Game);
                if (kspVessel.GetDisplaySpeed() > 15)
                {
                    // Example of how to maneuver the vessel
                    kspVessel.StartControlInstruction();
                    kspVessel.SetThrottle(0.5f);
                    kspVessel.SetRollTrim(1);
                    kspVessel.ExecuteControlInstruction();
                    
                    Log.LogInfo(kspVessel.GetDisplayAltitude());
                    
                }

                return;
            }
            
            
        }
    }
}