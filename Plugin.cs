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
        
        private float updateInterval = 0.01f;
        private float lastUpdate = 0;




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
            Log.LogInfo(Game.GlobalGameState.GetState().ToString());
            //Log.LogInfo(Game.GlobalGameState.GetState() == KSP.Game.GameState.MainMenu);
            
            if (Game.GlobalGameState.GetState() == KSP.Game.GameState.FlightView || Game.GlobalGameState.GetState() == KSP.Game.GameState.Map3DView)
            {
                KSPVessel kspVessel = new KSPVessel(Game);
                
                if (kspVessel.GetDisplaySpeed() > 250)
                {
                    kspVessel.SetThrottle(0);

                    
                }

                return;
            }
            
            
        }
    }
}