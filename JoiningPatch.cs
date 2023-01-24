using GorillaNetworking;
using HarmonyLib;
using UnityEngine;

namespace Shaddy_Anti_AC.Patches
{
    [HarmonyPatch(typeof(PhotonNetworkController), "ProcessJoiningFriendState")]
    public class JoiningPatch
    {
        [HarmonyPrefix]
        private static bool Prefix()
        {
            Debug.Log("-rep on the check for friends");
            return false;
        }
    }
}
