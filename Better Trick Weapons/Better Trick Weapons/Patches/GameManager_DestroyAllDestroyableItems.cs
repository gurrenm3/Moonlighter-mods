using HarmonyLib;
using System.Collections.Generic;

namespace Better_Trick_Weapons.Patches
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.DestroyAllDestroyableItems))]
    internal class GameManager_DestroyAllDestroyableItems
    {
		private static List<ItemStack> modifiedItems = new List<ItemStack>();

        [HarmonyPrefix]
        internal static bool Prefix()
        {
			if (HeroMerchant.Instance is null)
				return true;

            modifiedItems = new List<ItemStack>();
            List<ItemStack> equippedItems = HeroMerchant.Instance.heroMerchantInventory.equippedItems;
            foreach (var equippedItem in equippedItems)
            {
                if (equippedItem != null && equippedItem.TrickWeapon != null && equippedItem.master.isDestroyedOnRunEnded)
                {
                    equippedItem.master.isDestroyedOnRunEnded = false;
                    modifiedItems.Add(equippedItem);
                }
            }


            InventorySlot[] slots = HeroMerchant.Instance.heroMerchantInventory.slots;
            foreach (InventorySlot inventorySlot in slots)
            {
                if (inventorySlot.item != null && inventorySlot.item.TrickWeapon != null && inventorySlot.item.master.isDestroyedOnRunEnded)
                {
                    inventorySlot.item.master.isDestroyedOnRunEnded = false;
                    modifiedItems.Add(inventorySlot.item);
                }
            }

            return true;
        }


		[HarmonyPostfix]
		internal static void Postfix()
		{
			if (HeroMerchant.Instance is null)
				return;

            foreach (var item in modifiedItems)
                item.master.isDestroyedOnRunEnded = true;
        }
	}
}