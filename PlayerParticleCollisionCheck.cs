
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;


public class PlayerParticleCollisionCheck : UdonSharpBehaviour
{
    public Text textField;
    public override void OnPlayerParticleCollision(VRCPlayerApi myPlayer)
    {
        textField.text = string.Format("Particle Hit {0} at {1}", myPlayer.displayName, Time.time);
    }
}
