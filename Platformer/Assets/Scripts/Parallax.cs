using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject[] backgrounds; // array of all the backgrounds to be parallaxed
    public float parallaxScale; // the proportion of the camera's movement to move the backgrounds by
    public float parallaxReductionFactor; // how much less each successive layer should parallax
    public float smoothing; // how smooth the parallax effect should be

    private Vector3 previousCamPos; // position of camera in previous frame

    void Awake()
    {
        // set the previousCamPos to the current camera position
        previousCamPos = transform.position;
    }

    void Update()
    {
        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - transform.position.x) * parallaxScale;

            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].transform.position.x + parallax;

            // create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].transform.position = Vector3.Lerp(backgrounds[i].transform.position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = transform.position;
    }
}
