using HarmonyLib;
using UnityEngine;
using Moonlighter_Mod_Helper.Api;
using Moonlighter_Mod_Helper.Extensions;

namespace More_Potions.Patches
{
    [HarmonyPatch(typeof(HPPotionI), nameof(HPPotionI.OnEquipped))]
    internal class HPPotionI_OnEquipped
    {
        [HarmonyPrefix]
        internal static bool Prefix(HPPotionI __instance)
        {
            return true;
        }
    }
}