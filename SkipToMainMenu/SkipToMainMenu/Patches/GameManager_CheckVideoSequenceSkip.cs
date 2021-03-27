using HarmonyLib;

namespace SkipToMainMenu.Patches
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.CheckVideoSequenceSkip))]
    internal class GameManager_CheckVideoSequenceSkip
    {
        [HarmonyPostfix]
        internal static void Postfix(GameManager __instance)
        {
            if (__instance._startSequenceMovie is null)
                return;

            if (!__instance._startSequenceMovie.isPlaying)
                return;

            __instance._startSequenceMovie.SkipCurrent();
            __instance.DisableFor(0f);
        }
    }
}