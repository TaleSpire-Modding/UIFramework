using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace Hollo.UIFramework
{
    [BepInPlugin(Guid, Name, Version)]
    // [ScriptEngine]
    public partial class UIFramework : BaseUnityPlugin
	{
		// constants
		public const string Guid = "org.hollofox.plugins.UIFramework";
		public const string Name = "UIFramework";
		public const string Version = "1.0.0.0";
        private Harmony _harmony;

        /// <summary>
		/// Awake plugin
		/// </summary>
		void Awake()
		{
			Logger.LogInfo("In Awake for UIFramework");
            Debug.Log("UI Framework loaded"); 
            _harmony = new Harmony(Guid);
            _harmony.PatchAll();
            
            GameSettingsPatch.RefreshUI();
        }

        private void OnDestroy()
        {
            // Unpatch
            _harmony.UnpatchSelf();

            // Clear Data
            GameSettingsTabs.Clear();

            // Refresh UI
            GameSettingsPatch.RefreshUI();
        }
    }
}