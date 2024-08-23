using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReadyPlayerMe.Samples.AvatarLoading
{
    public class moveSlider : MonoBehaviour
    {
        public bool leftOrRight;

        private void OnTriggerEnter(Collider other)
        {
            HandCollision handCollider = other.GetComponent<HandCollision>();
            handCollider.leftOrRight = leftOrRight;
            handCollider.shouldMove = true;
        }

        private void OnTriggerExit(Collider other)
        {
            HandCollision handCollider = other.GetComponent<HandCollision>();
            handCollider.shouldMove = false;
        }
        void Update()
        {

        }
    }
}
