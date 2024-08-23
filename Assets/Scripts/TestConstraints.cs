using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Oculus.Movement.AnimationRigging
{
    public class TestConstraints : MonoBehaviour
    {
        public FullBodyDeformationConstraint rL; // Reference to the FullBodyDeformationConstraint component
        public float range; // Range of the value to be modified
        public int reverse = 1; // Direction of the range change (1 for increasing, -1 for decreasing)

        void Start()
        {
            // Initialization logic (if needed) can be placed here
        }

        // Update is called once per frame
        void Update()
        {
            // Modify the range value over time based on the direction (reverse)
            range += Time.deltaTime * reverse;

            // Reverse direction when reaching the upper limit
            if (range >= 1)
                reverse = -1;

            // Reverse direction when reaching the lower limit
            if (range <= 0)
                reverse = 1;
        }
    }
}
