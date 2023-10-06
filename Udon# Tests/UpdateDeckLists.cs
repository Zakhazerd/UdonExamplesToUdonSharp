
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class UpdateDeckLists : UpdatePlayerList
{
    public override void UpdatePlayerListString()
    {
        Debug.LogError("Updating deck Lists");
        VRCPlayerApi.GetPlayers(allPlayers);
        playerList = "";
        for (int i = 0; i < VRCPlayerApi.GetPlayerCount(); i++)
        {
            playerList = string.Concat(playerList, string.Format("{0} PlayerID: {1} DeckList: {2} \n", allPlayers[i].displayName, allPlayers[i].playerId.ToString(), GetDeckList(allPlayers[i].playerId)));
        }
        RequestSerialization();
        SendCustomEvent("UpdateList");
    }

    public string GetDeckList(int myPlayerId)
    {
        for(int i = 0; i < playerBehaviours.Length; i++)
        {
            Debug.LogError("OwnerID: " + VRCPlayerApi.GetPlayerId(Networking.GetOwner(playerBehaviours[i].gameObject)) + " myPlayerID: " + myPlayerId.ToString());
            if ((int)playerBehaviours[i].GetProgramVariable("myPlayerID") == myPlayerId && playerBehaviours[i].gameObject.activeSelf == true)
            {
                playerBehaviours[i].SendCustomEvent("SetDeckList");
                return (string)playerBehaviours[i].GetProgramVariable("deckListString");
            }

            //    Debug.LogError(playerBehaviours[i].GetProgramVariable("myScore"));
            // return (int)playerBehaviours[i].GetProgramVariable("myScore");

        }
        return "Empty";
    }
}
