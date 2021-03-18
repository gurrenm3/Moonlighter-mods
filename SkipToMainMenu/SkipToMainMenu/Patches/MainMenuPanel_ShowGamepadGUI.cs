using HarmonyLib;
using UnityEngine;

namespace Moonlighter_Practice_Mod.Patches
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