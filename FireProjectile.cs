
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class FireProjectile : UdonSharpBehaviour
{
    public Text textField;
    public Rigidbody myRigidbody;
    public ConstantForce force;
    private Vector3 orginalPosition = new Vector3(0.0f, 0.0f, 0.0f);
    void Start()
    {
        orginalPosition = myRigidbody.position;
    }

    void ResetCube()
    {
        myRigidbody.position = orginalPosition;
        myRigidbody.rotation = Quaternion.identity;
        myRigidbody.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        myRigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        force.enabled = false;
    }
    public void Fire()
    {
        ResetCube();
        force.enabled = true;
    }
    public override void OnPlayerCollisionExit(VRCPlayerApi myPlayer)
    {
        textField.text = string.Format("{0} Exited", myPlayer.displayName);
        ResetCube();
    }

    public override void OnPlayerCollisionEnter(VRCPlayerApi myPlayer)
    {
        textField.text = string.Format("{0} entered", myPlayer.displayName);
        myPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Left, 0.25f, 1.0f, 1.0f);
        myPlayer.PlayHapticEventInHand(VRC_Pickup.PickupHand.Right, 0.25f, 1.0f, 1.0f);
        Debug.Log("collision");

    }
}
