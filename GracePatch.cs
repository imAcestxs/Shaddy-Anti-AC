using HarmonyLib;
using UnityEngine;

namespace Shaddy_Anti_AC.Patches
{
    [HarmonyPatch]
    public class GracePatch
    {
        [HarmonyPatch(typeof(GorillaNetworkPublicTestsJoin), "GracePeriod")]
        [HarmonyPatch(typeof(GorillaNetworkPublicTestJoin2), "GracePeriod")]
        [HarmonyPrefix]
        private static bool Prefix()
        {
            Debug.Log("-rep graceperiod check ez bypass");
            return false;
        }
    }
}
