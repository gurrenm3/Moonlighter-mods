using HarmonyLib;

namespace Better_Trick_Weapons.Patches
{
    [HarmonyPatch(typeof(InventorySlotGUI), nameof(InventorySlotGUI.SetItemStack))]
    internal class InventorySlotGUI_SetItemStack
	{
		[HarmonyPrefix]
		internal static bool Prefix(InventorySlotGUI __instance, ItemStack stack)
		{
			var effect = stack?.effect;
			if (string.IsNullOrEmpty(effect?.name))
				return true;

			if (effect.name == "Trick")
				stack.DestroyEffect();

			return true;
		}
	}
}