using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReadyPlayerMe.Samples.AvatarLoading
{
    public class moveSlider : MonoBehaviour
    {
        public bool leftOrRight; // Indicates whether the slider should move left or right

        // This method is called when another collider enters the trigger collider attached to this GameObject
        private void OnTriggerEnter(Collider other)
        {
            // Check if the entering collider has a HandCollision component
            if (other.GetComponent<HandCollision>() != null)
            {
                // Get the HandCollision component from the collider
                HandCollision handCollider = other.GetComponent<HandCollision>();

                // Increment the fingerCount on the handCollider
                handCollider.fingerCount++;

                // Update the leftOrRight property of the handCollider to match this object's property
                handCollider.leftOrRight = leftOrRight;

                // Clamp fingerCount to a maximum of 5
                if (handCollider.fingerCount > 5)
                    handCollider.fingerCount = 5;
            }
        }

        // This method is called when another collider exits the trigger collider attached to this GameObject
        private void OnTriggerExit(Collider other)
        {
            // Check if the exiting collider has a HandCollision component
            if (other.GetComponent<HandCollision>() != null)
            {
                // Get the HandCollision component from the collider
                HandCollision handCollider = other.GetComponent<HandCollision>();

                // Decrement the fingerCount on the handCollider
                handCollider.fingerCount--;

                // Update the leftOrRight property of the handCollider to match this object's property
                handCollider.leftOrRight = leftOrRight;

                // Clamp fingerCount to a minimum of 0
                if (handCollider.fingerCount < 0)
                    handCollider.fingerCount = 0;
            }
        }
    }
}
