using BepInEx;
using HarmonyLib;

namespace Hollo.UIFramework
{
    public partial class UIFramework : BaseUnityPlugin
    {
       
    }

    [HarmonyPatch(typeof(CampaignInfoPanel), "Awake")]
    internal class CampaignInfoPanelPatch
    {
        public static void Postfix(CampaignInfoPanel __instance)
        {
            // Turns out most of the data is just text so we can append to it quite easily
            // Need to also update the live update feature when describing users
        }
    }
}
