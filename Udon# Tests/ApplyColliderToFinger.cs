
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ApplyColliderToFinger : UdonSharpBehaviour
{
    public GameObject[] colliderList = new GameObject[80];
    public VRCPlayerApi[] allPlayers = new VRCPlayerApi[80];

    public override void PostLateUpdate()
    {
        VRCPlayerApi.GetPlayers(allPlayers);


        if (!colliderList[0].activeSelf)
        {
            colliderList[0].SetActive(true);
        }
        float distance = Vector3.Distance(Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightIndexDistal), Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightIndexDistal));
        colliderList[0].transform.position = Networking.LocalPlayer.GetBonePosition(HumanBodyBones.RightIndexDistal) + new Vector3(0, -distance / 2, 0);
    }
     
    //public override void OnPlayerLeft(VRCPlayerApi myPlayer)
    //{
    //    colliderList[VRCPlayerApi.GetPlayerCount()-1].SetActive(false);
    //}
}
