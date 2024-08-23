using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject lockerRoom; // Reference to the GameObject representing the locker room
    public GameObject yogaRoom;   // Reference to the GameObject representing the yoga room
    public bool shouldTeleport = false; // Flag to control whether teleportation should occur

    // This method is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter(Collider other)
    {
        // Activate the yogaRoom GameObject and deactivate the lockerRoom GameObject
        yogaRoom.SetActive(true);
        lockerRoom.SetActive(false);

    }
}
