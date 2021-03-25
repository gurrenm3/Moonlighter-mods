using HarmonyLib;

namespace Bigger_ItemStacks.Patches
{
    [HarmonyPatch(typeof(MainMenuPanel), nameof(MainMenuPanel.Awake))]
    internal class MainMenuPanel_Enable
    {
        [HarmonyPostfix]
        internal static void Postfix(MainMenuPanel __instance)
        {
            foreach (var item in ItemDatabase.GetItems())
            {
                if (item.maxStack != Constants.maxStackSize)
                    item.maxStack = Constants.maxStackSize;

                if (item.maxChestStack != Constants.maxStackSize)
                    item.maxChestStack = Constants.maxStackSize;
            }
        }
    }
}