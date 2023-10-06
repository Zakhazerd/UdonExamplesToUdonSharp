
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ChangeMaterial : UdonSharpBehaviour
{
    public Material[] materials = new Material[3];
    public MeshRenderer mesh;
    private int materialIndex = 0;
    public void changeMaterial()
    {
        materialIndex++;
        materialIndex = materialIndex % materials.Length;
        mesh.material = materials[materialIndex];
        Debug.Log("event");
    }
}
