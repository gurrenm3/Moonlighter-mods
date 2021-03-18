using HarmonyLib;
using UnityEngine;

namespace SkipToMainMenu.Patches
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