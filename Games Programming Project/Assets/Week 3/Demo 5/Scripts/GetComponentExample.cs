using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponentExample : MonoBehaviour
{
    public GameObject chestObject;
    public Camera mainCamera;

    public void ChangeScale()
    {
        //creates a new scale vector and applies it to the object
        Vector3 scaleChange = new Vector3(Random.Range(0.5f, 3f), Random.Range(0.5f, 3f), Random.Range(0.5f, 3f));
        chestObject.transform.localScale = scaleChange;
    }

    public void ResetScale()
    {
        //Resets the scale
        Vector3 scaleReset = new Vector3(1,1,1);
        chestObject.transform.localScale = scaleReset;
    }

    public void ChangePosition()
    {
        //creates a new scale vector and applies it to the object
        Vector3 positionChange = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
        chestObject.transform.localPosition = positionChange;

    }

    public void ResetPosition()
    {
        //Resets the position
        Vector3 positionReset = new Vector3(0,0,0);
        chestObject.transform.localPosition = positionReset;

    }

    public void ChangeRotation()
    {
        //rotates teh object randomly around its three axis
        chestObject.transform.Rotate(Random.Range(0,360f), Random.Range(0,360f), Random.Range(0,360f), Space.World);
    }

    public void ResetRotation()
    {
        //puts the rotation back using quarternions
        chestObject.transform.rotation = Quaternion.identity;
    }

    public void OpenTheLid()
    {
        //rotates just the children
        chestObject.transform.GetChild(0).transform.Rotate(-45f,0,0);
    }

    public void CloseTheLid()
    {
        //fixes the children in relation to the parent
        chestObject.transform.GetChild(0).transform.localRotation = Quaternion.identity;
    }

    public void DropIt()
    {
        //Adds gravity to the object
        chestObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void MakeItNice()
    {
        mainCamera.backgroundColor = new Color (Random.Range(0.4f, 1f), Random.Range(0.4f, 1f), Random.Range(0.4f, 1f));
    }
}
