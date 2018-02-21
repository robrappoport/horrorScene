using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FOV = "field of view"
// put this script on the object to be looked at
// and this script will ask itself, "am I being looked at?"
public class FOVGazeTrigger : MonoBehaviour
{
    public Vector3 startLoc;
    // Update is called once per frame

    private void Start()
    {
        startLoc = transform.position;
    }
    void Update()
    {
        // 1. am I within the Camera's field of view? / middle of the screen?

        // get vector from camera to object
        Vector3 fromCameraToMe = transform.position - Camera.main.transform.position;

        // compare that vector to camera's forward direction, and measure the angle
        float angle = Vector3.Angle(Camera.main.transform.forward, fromCameraToMe.normalized);

        // if that angle is less than X, then that object is within the vision cone
        if (angle < 40f)
        { // if within 10 degrees of middle of screen, then... etc etc
            transform.Translate(0f, 0f, .3f * Time.deltaTime); // test: rotate

            // if you wanted to make sure there's nothing blocking our view,
            // you would add a raycast check here, between Camera.main and this.transform
            // (see GazeRaycast.cs for that kind of stuff)
        }
       
        else
        {
            Vector3 currentPos = transform.position;
            transform.position = Vector3.Lerp(currentPos, startLoc, Time.deltaTime/3f);
        }

    }
}