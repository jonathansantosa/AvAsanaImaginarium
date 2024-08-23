using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReadyPlayerMe.Samples.AvatarLoading
{
    public class HandCollision : MonoBehaviour
    {
        public int fingerCount;
        public Transform leftHand;
        public Transform rightHand;
        public Transform slider;
        public bool leftOrRight;
        public float midValue = 1.25f;
        public float value = 1f;
        public bool shouldMove = false;
        void Start()
        {
            slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, slider.transform.localPosition.y, - 0.117f);
        }

        // Update is called once per frame
        private void Update()
        {
            if (shouldMove) { 
               if (leftOrRight)
                {
                    slider.transform.position = new Vector3(rightHand.position.x, slider.transform.position.y, slider.transform.position.z);
                    if (slider.transform.localPosition.z < -0.35f)
                        slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, slider.transform.localPosition.y, -0.35f);
                    if (slider.transform.localPosition.z > 0.35f)
                        slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, slider.transform.localPosition.y, 0.35f);
                }
                else
                {
                    slider.transform.position = new Vector3(leftHand.position.x, slider.transform.position.y, slider.transform.position.z);
                    if (slider.transform.localPosition.z < -0.35f)
                        slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, slider.transform.localPosition.y, -0.35f);
                    if (slider.transform.localPosition.z > 0.35f)
                        slider.transform.localPosition = new Vector3(slider.transform.localPosition.x, slider.transform.localPosition.y, 0.35f);
                }
            }
            value = midValue + (15 / 7) * (slider.transform.localPosition.z);
        }
    }
}