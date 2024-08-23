using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReadyPlayerMe.Core.Editor{
public class AudioDelayStart : MonoBehaviour
{
    //reference the audio handler
    //float variable for delay seconds
    [SerializeField] private float delay;
    [SerializeField] private VoiceHandler target;


    public GameObject[] walls;
        public GameObject lockerRoom;
        public GameObject yogaRoom;

    // Start is called before the first frame update
    void Start()
    {
        //start coroutine(delayStart)
        StartCoroutine(DelayStart());

    }
    public void changeSkyBox()
    {
            yogaRoom.SetActive(false);
            lockerRoom.SetActive(true);
            for(int a = 0; a<walls.Length; a++)
            {
                walls[a].SetActive(false);
            }
    }

    IEnumerator DelayStart()
    {
        //WaitForSeconds(float)
        //ask audio handler to PlayCurrentAudioClip()
        //Print the time of when the function is first called.
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(delay);

        //After we have waited 5 seconds print the time again.
        // Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        ((VoiceHandler) target).PlayCurrentAudioClip();
    }
}
}
