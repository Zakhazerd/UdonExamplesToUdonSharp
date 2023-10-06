
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class UpdatePlayerList : UdonSharpBehaviour
{
    public Text playerListText;
    public VRCPlayerApi[] allPlayers = new VRCPlayerApi[80];
    public UdonBehaviour[] playerBehaviours = new UdonBehaviour[80];
    [UdonSynced]
    public string playerList;
    public override void OnPlayerJoined(VRCPlayerApi myPlayer)
    {
        if (Networking.IsOwner(gameObject))
        {
            for (int i = 0; i < playerBehaviours.Length; i++)
            {
                if (!playerBehaviours[i].gameObject.activeSelf)
                {
                    Networking.SetOwner(myPlayer, playerBehaviours[i].gameObject);
                    playerBehaviours[i].gameObject.SetActive(true);
                    break;
                }

            }
        }
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");



    }
    public virtual void UpdatePlayerListString()
    {
        VRCPlayerApi.GetPlayers(allPlayers);
        playerList = "";
        for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
        {
            playerList = string.Concat(playerList, string.Format(" {0} PlayerID: {1} Score: {2} \n", allPlayers[i].displayName, allPlayers[i].playerId.ToString(), GetScore(allPlayers[i].playerId)));
        }
        RequestSerialization();
        SendCustomEvent("UpdateList");
    }
   
    public override void OnPlayerLeft(VRCPlayerApi myPlayer)
    {
        if (Networking.IsOwner(gameObject))
        {
            for (int i = 0; i < playerBehaviours.Length; i++)
            {
                if (playerBehaviours[i].gameObject.activeSelf && (int)playerBehaviours[i].GetProgramVariable("myPlayerID") == myPlayer.playerId)
                {
                    Networking.SetOwner(Networking.GetOwner(gameObject), playerBehaviours[i].gameObject);
                    playerBehaviours[i].SendCustomEvent("ClearInfo");
                  
                    playerBehaviours[i].gameObject.SetActive(false);
                //    playerBehaviours[i].gameObject.SetActive(false);
                    break;
                }

            }
        }
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");

    }
    public override void OnDeserialization()
    {
        SendCustomEvent("UpdateList");

    }
    public void UpdateList()
    {

        playerListText.text = playerList;

    }

    public int GetScore(int myPlayerId)
    {
        for(int i = 0; i < playerBehaviours.Length; i++)
        {
            Debug.LogError("OwnerID: " + VRCPlayerApi.GetPlayerId(Networking.GetOwner(playerBehaviours[i].gameObject)) + " myPlayerID: " + myPlayerId.ToString());
            if ((int)playerBehaviours[i].GetProgramVariable("myPlayerID") == myPlayerId)
            {
                return (int)playerBehaviours[i].GetProgramVariable("myScore");
            }
            
            //    Debug.LogError(playerBehaviours[i].GetProgramVariable("myScore"));
               // return (int)playerBehaviours[i].GetProgramVariable("myScore");
            
        }
        return 0;
    }
   
  
}
