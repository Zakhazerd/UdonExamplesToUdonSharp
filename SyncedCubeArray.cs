
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SyncedCubeArray : UdonSharpBehaviour
{
    
    public GameObject[] cubes = new GameObject[25];
    [UdonSynced]
    private bool[] data = new bool[25];
    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "Randomize");
    }

    public void Randomize()
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (.5 > Random.value);
        }
        RequestSerialization();
        SendCustomEvent("UpdateCubes");
    }

    public override void OnDeserialization()
    {
        SendCustomEvent("UpdateCubes");
    }
    public void UpdateCubes()
    {
        for(int i = 0; i < cubes.Length;i++)
        {
            cubes[i].SetActive(data[i]);
        }
    }

}

