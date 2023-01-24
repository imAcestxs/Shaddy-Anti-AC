using HarmonyLib;
using UnityEngine;

namespace Shaddy_Anti_AC.Patches
{
    [HarmonyPatch]
    public class NormalizePatch
    {
        [HarmonyPatch(typeof(GorillaGameManager), "NormalizeName")]
        [HarmonyPatch(typeof(GorillaPlayerScoreboardLine), "NormalizeName")]
        [HarmonyPrefix]
        private static bool Prefix()
        {
            Debug.Log("-rep didnt normalize");
            return false;
        }
    }
}
