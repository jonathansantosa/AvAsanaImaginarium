using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeController : MonoBehaviour
{
    [SerializeField] string eyeName; // Name of the GameObject representing the eye
    [SerializeField] GameObject eye; // Reference to the GameObject representing the eye
    [SerializeField] OVREyeGaze eyeGaze; // Reference to the OVREyeGaze component for eye tracking
    public bool inVR = false; // Flag to determine if VR mode is active

    // Start is called before the first frame update
    void Start()
    {
        // Find and assign the eye GameObject if it is not set via the Inspector
        // eye = GameObject.Find(eyeName);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the eyeGaze reference is assigned
        if (eyeGaze == null) return;

        // If VR is not active, rotate the eye GameObject based on time
        if (!inVR)
        {
            // Rotate the eye GameObject around the Y-axis at a rate proportional to time
            eye.transform.localRotation = Quaternion.Euler(0f, Time.time * 15, 0f);
            return;
        }

        // If VR is active and eye tracking is enabled, match the eye's rotation to the eyeGaze's rotation
        if (eyeGaze.EyeTrackingEnabled)
        {
            // Set the rotation of the eye GameObject to match the rotation of the eyeGaze component
            eye.transform.rotation = eyeGaze.transform.rotation;
        }
    }
}

