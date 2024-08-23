using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ReadyPlayerMe.Samples.AvatarLoading
{
    public class CustomAvatar : MonoBehaviour
    {
        public HandCollision[] slider;
        public string type;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (type.Equals("Head"))
            {
                this.transform.localScale = new Vector3((slider[0].value + slider[1].value) / 2, (slider[0].value + slider[2].value) / 2, (slider[0].value + slider[3].value) / 2);
                //for (int a = 0; a < this.transform.childCount; a++)
                // this.transform.GetChild(a).localScale = new Vector3(1 / ((slider[0].value + slider[1].value) / 2), 1 / ((slider[0].value + slider[2].value) / 2), 1 / ((slider[0].value + slider[3].value) / 2));
            }
            /* else if (axis == 2)
             {

                 this.transform.localScale = new Vector3((slider[0].value + slider[1].value) / 2, (slider[0].value + slider[2].value) / 2 * template.height / 160, (slider[0].value + slider[3].value) / 2);
                 for (int a = 0; a < this.transform.childCount; a++)
                         this.transform.GetChild(a).localScale = new Vector3(1 / ((slider[0].value + slider[1].value) / 2), 1 / ((slider[0].value + slider[2].value) / 2), 1 / ((slider[0].value + slider[3].value) / 2));
             }*/
            else if (type.Equals("RightUpLeg") || type.Equals("LeftUpLeg"))
            {
                CustomAvatar parentBody = this.transform.parent.gameObject.GetComponent<CustomAvatar>();
                float parentX = (parentBody.slider[0].value + parentBody.slider[1].value) / 2;
                float parentY = (parentBody.slider[0].value + parentBody.slider[2].value) / 2;
                float parentZ = (parentBody.slider[0].value + parentBody.slider[3].value) / 2;
                this.transform.localScale = new Vector3(1 / parentX * (slider[0].value + slider[1].value) / 2, 1 / parentY * (slider[0].value + slider[2].value) / 2, 1 / parentZ * (slider[0].value + slider[3].value) / 2);
            }
            else if (type.Equals("RightShoulder") || type.Equals("LeftShoulder"))
            {
                CustomAvatar parentBody = this.transform.parent.gameObject.GetComponent<CustomAvatar>();
                float parentX = (parentBody.slider[0].value + parentBody.slider[1].value) / 2;
                float parentY = (parentBody.slider[0].value + parentBody.slider[2].value) / 2;
                float parentZ = (parentBody.slider[0].value + parentBody.slider[3].value) / 2;
                this.transform.localScale = new Vector3(1 / parentX * (slider[0].value + slider[1].value) / 2, 1 / parentY * (slider[0].value + slider[2].value) / 2, 1 / parentZ * (slider[0].value + slider[3].value) / 2);
            }
            else if (type.Equals("Spine2"))
            {
                this.transform.localScale = new Vector3((slider[0].value + slider[1].value) / 2, (slider[0].value + slider[2].value) / 2, (slider[0].value + slider[3].value) / 2);
                for (int a = 0; a < this.transform.childCount; a++)
                {
                    if (this.transform.GetChild(a).gameObject.GetComponent<CustomAvatar>() == null)
                        this.transform.GetChild(a).localScale = new Vector3(1 / ((slider[0].value + slider[1].value) / 2), 1 / ((slider[0].value + slider[2].value) / 2), 1 / ((slider[0].value + slider[3].value) / 2));
                }
            }
            else if (type.Equals("Spine"))
            {
                CustomAvatar parentBody = this.transform.parent.gameObject.GetComponent<CustomAvatar>();
                float parentX = (parentBody.slider[0].value + parentBody.slider[1].value) / 2;
                float parentY = (parentBody.slider[0].value + parentBody.slider[2].value) / 2;
                float parentZ = (parentBody.slider[0].value + parentBody.slider[3].value) / 2;
                this.transform.localScale = new Vector3(1 / parentX * (slider[0].value + slider[1].value) / 2, 1 / parentY * (slider[0].value + slider[2].value) / 2, 1 / parentZ * (slider[0].value + slider[3].value) / 2);
                for (int a = 0; a < this.transform.childCount; a++)
                {
                    if (this.transform.GetChild(a).gameObject.GetComponent<CustomAvatar>() == null)
                        this.transform.GetChild(a).localScale = new Vector3(1 / ((slider[0].value + slider[1].value) / 2), 1 / ((slider[0].value + slider[2].value) / 2), 1 / ((slider[0].value + slider[3].value) / 2));
                }
            }
            else if (type.Equals("Hips"))
            {
                this.transform.localScale = new Vector3((slider[0].value + slider[1].value) / 2, (slider[0].value + slider[2].value) / 2, (slider[0].value + slider[3].value) / 2);
                for (int a = 0; a < this.transform.childCount; a++)
                {
                    if (this.transform.GetChild(a).gameObject.GetComponent<CustomAvatar>() == null)
                        this.transform.GetChild(a).localScale = new Vector3(1 / ((slider[0].value + slider[1].value) / 2), 1 / ((slider[0].value + slider[2].value) / 2), 1 / ((slider[0].value + slider[3].value) / 2));
                }
            }
        }
    }
}
