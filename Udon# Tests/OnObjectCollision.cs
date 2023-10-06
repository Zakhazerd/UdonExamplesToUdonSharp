
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnObjectCollision : UdonSharpBehaviour
{
    public Rigidbody myRigidbody;
    public Transform pushDistance;
    public GameObject toPush;
    public GameObject meshToMove;
    public GameObject forScale;
    private float magicNumber;
    public float activationPoint = .1f;
    public float deactivationPoint = .15f;
    public float lerpTime = .25f;
    public UdonBehaviour toTrigger;
    Plane toPushPlane;
    private Vector3 onLeavePosition;
    float distanceToOrginal;
    bool isColliding;
    float leaveTime;
    private bool isActive = true;

    public void Start()
    {
        magicNumber = (float)0.142521 * (float)forScale.transform.lossyScale.y;
        Debug.LogError("MagicNumber: " +magicNumber);
        toPushPlane = new Plane(toPush.transform.forward, toPush.transform.position);

    }
    public void OnTriggerEnter(Collider myCollider)
    {
        isColliding = true;
        toPushPlane = new Plane(toPush.transform.forward, toPush.transform.position);
        float distance = Mathf.Abs(toPushPlane.GetDistanceToPoint(myCollider.transform.localPosition));
        float distanceDifference = magicNumber - distance;
        if (distanceDifference > 0)
        {
            meshToMove.transform.localPosition = toPush.transform.localPosition - new Vector3(0, distanceDifference, 0);
        }
     //   Debug.Log(distance);
        if (distanceDifference > activationPoint && isActive == false)
        {
            toTrigger.SendCustomEvent("SendReset");

            Debug.LogError("distanceDifference: " + distanceDifference + " activationPoint: " + activationPoint);
            isActive = true;
        }
        else if (distanceDifference < deactivationPoint && isActive == true)
        {
            isActive = false;
        }


    }
    public void OnTriggerStay(Collider myCollider)
    {
        toPushPlane = new Plane(toPush.transform.forward, toPush.transform.position);
        float distance = Mathf.Abs(toPushPlane.GetDistanceToPoint(myCollider.transform.localPosition));
        float distanceDifference = magicNumber - distance;

        if (distanceDifference > 0)
        {
            meshToMove.transform.localPosition = toPush.transform.localPosition - new Vector3(0, distanceDifference, 0);
        }
        if (distanceDifference > activationPoint && isActive == false)
        {
            toTrigger.SendCustomEvent("OnClick");

            Debug.LogError("distanceDifference: " + distanceDifference + " activationPoint: " + activationPoint);
            isActive = true;
        }
        else if (distanceDifference < deactivationPoint && isActive == true)
        {
            isActive = false;
        }
        //else
        //{
        //    Debug.Log("Distance: " + distance + " AP: " + activationPoint + " Active: " +isActive);
        //}
        


    }

    public void OnTriggerExit(Collider myCollider)
    {
        isColliding = false;

        toPushPlane = new Plane(toPush.transform.forward, toPush.transform.position);
        float distance = Mathf.Min(Mathf.Abs(toPushPlane.GetDistanceToPoint(myCollider.transform.localPosition)),magicNumber);
        float distanceDifference = magicNumber - distance;
        if (distanceDifference > 0)
        {
            meshToMove.transform.localPosition = toPush.transform.localPosition - new Vector3(0, distanceDifference, 0);
        }
        Debug.Log(distance);
        leaveTime = Time.time;
        if (distanceDifference > activationPoint && isActive == false)
        {
            toTrigger.SendCustomEvent("OnClick");
            Debug.LogError("distanceDifference: " + distanceDifference + " activationPoint: " + activationPoint);
            isActive = true;
        }
        else if (distanceDifference < deactivationPoint && isActive == true)
        {
            isActive = false;
        }

    }
     private void FixedUpdate()
    {
        if(!isColliding && meshToMove.transform.localPosition != toPush.transform.localPosition)
        {
            meshToMove.transform.localPosition = Vector3.Lerp(toPush.transform.localPosition, meshToMove.transform.localPosition, Mathf.Min(lerpTime / (Time.time - leaveTime), 1f));
        }
    }
}
