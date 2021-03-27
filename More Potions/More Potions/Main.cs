using BepInEx;
using HarmonyLib;
using Moonlighter_Mod_Helper.Api;
using Moonlighter_Mod_Helper.Extensions;
using System;
using System.Reflection;
using UnityEngine;

namespace More_Potions
{
    [BepInPlugin("GurrenM4.More_Potions", "More_Potions", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        internal static Assembly modAssembly = Assembly.GetExecutingAssembly();
        internal static string modName = $"{modAssembly.GetName().Name}";
        internal static string modDir = $"{Environment.CurrentDirectory}\\BepInEx\\{modName}";

        void Awake()
        {
            new Harmony($"GurrenM4_{modName}").PatchAll(modAssembly);
            Logger.LogInfo($"{modName} has loaded");
        }

        void Update()
        {
            /// this is the code ///
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                var item = HeroMerchant.Instance.heroMerchantInventory.GetEquippedStackBySlot(HeroMerchantInventory.EquipmentSlot.Potion);
                item.Consumable.gameObject.AddComponent<SpeedPotion>();

                var consumableChecker = new ConsumableChecker();
                item.SendMessage("CanConsume", consumableChecker, SendMessageOptions.RequireReceiver);

                var components = item.GetComponents<Component>();
                foreach (var component in components)
                {
                    Console.WriteLine(component.GetType());
                }
            }
        }   
    }
}