
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class PlayerBehavior : UdonSharpBehaviour
{
    public UdonBehaviour playerLog;
    public GameObject toActive;
    public string deckListString;
    public int indexPosition;
    [UdonSynced]
    public int myScore = 0;
    [UdonSynced]
    public int myPlayerID = -1;
    [UdonSynced]
    private int[] deckList = new int[10];

    private void Start()
    {
        if (Networking.IsOwner(gameObject)) 
        {
            toActive.SetActive(true);
            myPlayerID = Networking.GetOwner(gameObject).playerId;
            myScore = 0;
            ClearDeckList();
            RequestSerialization();
        }
    }
    //public void OnClick()
    //{
    //    if (Networking.IsOwner(gameObject))
    //    {
    //        myScore++;

    //        Debug.LogError(myScore);
    //        RequestSerialization();
    //        playerLog.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");
    //    }
    //}

    public void OnClick()
    {
        playerLog.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");
        Debug.LogError("I was pressed");

    }
    //public override void OnDeserialization()
    //{
    //    playerLog.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");
    //}

    public void ClearDeckList()
    {
        for (int i = 0; i < deckList.Length; i++)
        {
            deckList[i] = 0;
        }

    }
    public void SetDeckList()
    {
        deckListString = "";
        for(int i = 0; i < deckList.Length; i++)
        {
          //  Debug.LogError("DeckList " + i + ": " + deckList[i]);
            deckListString = string.Concat(deckListString, string.Format("{0} ", deckList[i].ToString()));
        }
      //  Debug.LogError(deckListString);
        RequestSerialization();
    }
    public void ClearInfo()
    {
        myScore = 0;
        myPlayerID = -1;
        RequestSerialization();
        gameObject.SetActive(false);
    }
    
    public void IndexLeft()
    {
        indexPosition = Mathf.Max(--indexPosition, 0);
    }
    public void IndexRight()
    {
        indexPosition = Mathf.Min(++indexPosition, 40);
    }

    public void IncrementIndex()
    {
        deckList[indexPosition] = (deckList[indexPosition] + 1 ) % 10;
        playerLog.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "UpdatePlayerListString");
        RequestSerialization();
    }


}
