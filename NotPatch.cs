using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace Shaddy_Anti_AC.Patches
{
    [HarmonyPatch]
    public class NotPatch
    {
        [HarmonyPatch(typeof(GorillaNot), "IncrementRPCCall")]
        [HarmonyPatch(typeof(GorillaNot), "SendReport")]
        [HarmonyPatch(typeof(GorillaNot), "LogErrorCount")]
        [HarmonyPatch(typeof(GorillaNot), "CheckReports")]
        [HarmonyPrefix]
        private static bool Prefix()
        {
            Debug.Log("-rep blocked gorillanot ac event");
            if (GorillaNot.instance.userRPCCallsMax.ContainsKey(PhotonNetwork.LocalPlayer.UserId))
            {
                GorillaNot.instance.userRPCCallsMax.Remove(PhotonNetwork.LocalPlayer.UserId);
            }
            if (GorillaNot.instance.userRPCCalls.ContainsKey(PhotonNetwork.LocalPlayer.UserId))
            {
                GorillaNot.instance.userRPCCalls.Remove(PhotonNetwork.LocalPlayer.UserId);
            }
            return false;
        }
    }
}
