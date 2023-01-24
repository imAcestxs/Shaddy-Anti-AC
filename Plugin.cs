using BepInEx;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace Shaddy_Anti_AC
{
    [BepInPlugin("ace.shaddyaac", "Shaddy Anti-AC", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            var harmony = new Harmony("ace.shaddyaac");
            harmony.PatchAll();
            Debug.Log("Patched Shady Anti-AC!");
        }

        public void SendReport(ref string susReason, ref string susId, ref string susNick)
        {
            susReason = null;
            susId = null;
            susNick = null;
        }

        public void LogErrorCount(ref string logString, ref string stackTrace, ref LogType type)
        {
            logString = null;
            stackTrace = null;
            type = LogType.Exception;
        }
    }
}
