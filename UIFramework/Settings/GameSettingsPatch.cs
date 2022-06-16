using System.Collections.Generic;
using BepInEx;
using UnityEngine;
using HarmonyLib;

namespace Hollo.UIFramework
{
    public partial class UIFramework : BaseUnityPlugin
    {
        internal static Dictionary<string,UIData> GameSettingsTabs = new Dictionary<string, UIData>();

        public static void AddSettingsTab(string uniqueId, UIData data)
        {
            GameSettingsTabs.Add(uniqueId,data); 
            GameSettingsPatch.addSettingsTab(uniqueId,data);
        }
        
        public static void RemoveSettingsTab(string uniqueId)
        {
            GameSettingsTabs.Remove(uniqueId);
            GameSettingsPatch.RefreshUI();
        }
    }

    [HarmonyPatch(typeof(GameSettings), "InitStaticSettings")]
    internal class GameSettingsPatch
    {
        internal static GameObject Instance;


        internal static void Postfix(GameSettings __instance)
        {
            if (__instance.gameObject.name == "##GAMESETTINGS##(Clone)")
            {
                Instance = __instance.gameObject;

                Debug.Log("InitStaticSettings Postfix Called");
                foreach (var tab in UIFramework.GameSettingsTabs)
                {
                    addSettingsTab(tab.Key,tab.Value);
                }
            }
        }

        /// <summary>
        /// Destroys the UI(open/closed) and re-opens if was opened to apply/remove patch.
        /// </summary>
        internal static void RefreshUI()
        {
            var gsInstance = GameObject.Find("##GAMESETTINGS##(Clone)");
            if (gsInstance != null)
            {
                bool open = gsInstance.gameObject.activeSelf;
                Object.Destroy(gsInstance);
                Instance = null;
                if (open) GameSettings.ToggleOpen();
            }
        }

        internal static void addSettingsTab(string id, UIData data)
        {
            if (Instance != null)
            {
                
            }
        }
    }
}
