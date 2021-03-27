using Moonlighter_Mod_Helper.Api.Items;
using Moonlighter_Mod_Helper.Extensions;
using UnityEngine;

namespace More_Potions.Potions
{
    class SpeedPotionI : Potion
    {
        public float speedBonus = 20f;

        public SpeedPotionI()
        {
            ItemName = "SpeedPotionI";
            ItemDescription = "Make yourself a little faster";
        }

        public override void CanConsume(ConsumableChecker consumableChecker)
        {
            System.Console.WriteLine("Speed Potion Can Consume called");
        }

        public override void Consume()
        {
            System.Console.WriteLine("=============== Speed Potion Consumed ===============");
            //HeroMerchant.Instance.heroMerchantStats.speed.Value += speedBonus;
            //PlayPotionSound();
        }

        void Update()
        {
            System.Console.WriteLine("++++ Speed Potion Update() ++++");
        }
    }
}
