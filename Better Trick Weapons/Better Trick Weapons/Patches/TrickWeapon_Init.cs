using DG.Tweening;
using HarmonyLib;
using Moonlighter.Weapons;
using System.Collections.Generic;
using UnityEngine;

namespace Better_Trick_Weapons.Patches
{
    [HarmonyPatch(typeof(TrickWeapon), nameof(TrickWeapon.Init))]
    internal class TrickWeapon_Init
	{
		[HarmonyPrefix]
		internal static bool Prefix(TrickWeapon __instance, TrickWeaponMaster master)
		{
			/*master.goldValue = 9999;
			master.wandererWeaponGoldCost = 9999;*/
			return true;
		}


		[HarmonyPostfix]
		internal static void Postfix(TrickWeapon __instance, TrickWeaponMaster master)
		{
            /*System.Console.WriteLine(master.name);
            System.Console.WriteLine(master.goldValue);
            System.Console.WriteLine("");*/
		}
	}
}