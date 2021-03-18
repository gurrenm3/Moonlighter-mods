using HarmonyLib;
using UnityEngine;

namespace QuickStart_Game.Patches
{
    [HarmonyPatch(typeof(MainMenuPanel), nameof(MainMenuPanel.CheckContinueAndSelectFirstButton))]
    internal class MainMenuPanel_CheckContinueAndSelectFirstButton
    {
        [HarmonyPostfix]
        internal static void Postfix(MainMenuPanel __instance)
        {
            if (__instance.HasLoadedGame)
                __instance.StartGame();
        }
    }
}