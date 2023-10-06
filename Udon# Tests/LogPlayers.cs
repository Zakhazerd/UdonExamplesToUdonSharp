
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class LogPlayers : UdonSharpBehaviour
{
    public VRCPlayerApi[] allPlayers = new VRCPlayerApi[80];

    public void OnMouseDown()
    {
        string output = "";
        VRCPlayerApi.GetPlayers(allPlayers);

        for (int i = 0; allPlayers[i] != null; i++)
        {
            output = string.Concat(output, allPlayers[i].displayName + " " + allPlayers[i].playerId);
        }
        Debug.LogError(output);
    }
}
