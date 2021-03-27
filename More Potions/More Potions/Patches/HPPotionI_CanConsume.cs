using HarmonyLib;
using UnityEngine;
using Moonlighter_Mod_Helper.Api;
using Moonlighter_Mod_Helper.Extensions;

namespace More_Potions.Patches
{
    [HarmonyPatch(typeof(HPPotionI), nameof(HPPotionI.CanConsume))]
    internal class HPPotionI_CanConsume
    {
        [HarmonyPrefix]
        internal static bool Prefix(HPPotionI __instance)
        {
            return true;
        }

        [HarmonyPostfix]
        internal static void Postfix(HPPotionI __instance)
        {
            System.Console.WriteLine("HPPotionI CanConsume called");
        }
    }
}