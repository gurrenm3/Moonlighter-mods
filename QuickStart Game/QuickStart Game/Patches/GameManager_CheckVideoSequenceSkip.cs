using HarmonyLib;
using InControl;
using Moonlighter_Mod_Helper.Api;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;

namespace QuickStart_Game.Patches
{
    [HarmonyPatch(typeof(GameManager), nameof(GameManager.CheckVideoSequenceSkip))]
    internal class GameManager_CheckVideoSequenceSkip
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codeInstructions = new List<CodeInstruction>(instructions);
            var transpiler = new BaseTranspilerPatch(codeInstructions, new List<OpCode>() { OpCodes.Callvirt });

            for (int i = 0; i < codeInstructions.Count; i++)
            {
                if (!transpiler.IsCurrentInstructionGood(i))
                    continue;

                var newInstruction = transpiler.CreateNewCodeInstruction<GameManager_CheckVideoSequenceSkip>(nameof(SkipVideo));
                codeInstructions[i] = newInstruction;
                break;
            }

            return codeInstructions.AsEnumerable();
        }

        public static bool SkipVideo(PlayerAction action)
        {
            return true;
        }
    }
}