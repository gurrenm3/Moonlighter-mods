using HarmonyLib;
using UnityEngine;

namespace Moonlighter_Practice_Mod.Patches
{
    [HarmonyPatch(typeof(MainMenuPanel), nameof(MainMenuPanel.PlayPressKeyReminderAnimationDelayed))]
    internal class MainMenuPanel_PlayPressKeyReminderAnimationDelayed
    {
        [HarmonyPostfix]
        internal static void Postfix(MainMenuPanel __instance)
        {
            __instance.PlayOpenAnimation();
            __instance.StopPressKeyReminderAnimation();
        }
    }
}