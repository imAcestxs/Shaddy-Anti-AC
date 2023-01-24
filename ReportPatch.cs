using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Shaddy_Anti_AC.Patches
{
    [HarmonyPatch(typeof(GorillaTagManager), "ReportTag")]
    public class ReportPatch
    {
        [HarmonyPrefix]
        private static bool Prefix(Player taggedPlayer, Player taggingPlayer)
        {
            Debug.Log("-rep pls no report for tag!!");
            foreach (GorillaTagManager gorillaTagManager in UnityEngine.Object.FindObjectsOfType<GorillaTagManager>())
            {
                if (gorillaTagManager.photonView.IsMine && gorillaTagManager.IsGameModeTag())
                {
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions();
                    WebFlags flags = new WebFlags(1);
                    raiseEventOptions.Flags = flags;
                    byte b = 0;
                    int num = 0;
                    if (gorillaTagManager.isCurrentlyTag)
                    {
                        if (taggingPlayer == gorillaTagManager.currentIt && taggingPlayer != taggedPlayer && (double)Time.time > gorillaTagManager.lastTag + (double)gorillaTagManager.tagCoolDown)
                        {
                            gorillaTagManager.ChangeCurrentIt(taggedPlayer);
                            new ExitGames.Client.Photon.Hashtable();
                            gorillaTagManager.lastTag = (double)Time.time;
                            b = 1;
                        }
                    }
                    else if (gorillaTagManager.currentInfected.Contains(taggingPlayer) && !gorillaTagManager.currentInfected.Contains(taggedPlayer) && (double)Time.time > gorillaTagManager.lastTag + (double)gorillaTagManager.tagCoolDown)
                    {
                        gorillaTagManager.AddInfectedPlayer(taggedPlayer);
                        num = gorillaTagManager.currentInfected.Count;
                        b = 2;
                    }
                    if (b == 1)
                    {
                        object[] eventContent = new object[]
                        {
                            taggingPlayer.UserId,
                            taggedPlayer.UserId
                        };
                        PhotonNetwork.RaiseEvent(1, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    }
                    if (b == 2)
                    {
                        object[] eventContent2 = new object[]
                        {
                            taggingPlayer.UserId,
                            taggedPlayer.UserId,
                            num
                        };
                        PhotonNetwork.RaiseEvent(2, eventContent2, raiseEventOptions, SendOptions.SendReliable);
                    }
                }
            }
            return false;
        }
    }
}
