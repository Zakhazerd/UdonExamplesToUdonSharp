
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnPickupandUse : UdonSharpBehaviour
{
    private Material material;
    void Start()
    {

        material = GetComponent<MeshRenderer>().material;
    }
    void OnPickupUseUp()
    {

        material.color = Color.green;

    }

    void OnPickupUseDown()
    {
        material.color = Color.red;
    }
}
