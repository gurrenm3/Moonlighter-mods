using HarmonyLib;
using UnityEngine;

namespace QuickStart_Game.Patches
{
    [HarmonyPatch(typeof(MainMenuPanel), nameof(MainMenuPanel.ShowGamepadGUI))]
    internal class MainMenuPanel_ShowGamepadGUI
    {
        [HarmonyPostfix]
        internal static void Postfix(MainMenuPanel __instance)
        {
            __instance.CloseGamepadPanel();
        }
    }
}