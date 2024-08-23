using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext : MonoBehaviour
{
    public GameObject TransportedObject; // Reference to the GameObject that should not be destroyed on scene load
    public GameObject spawnedObject; // Reference to the GameObject whose position will be used for teleporting

    // Start is called before the first frame update
    void Start()
    {
        // Ensure that TransportedObject persists across scene loads
        DontDestroyOnLoad(TransportedObject);
    }

    // Method to load the next scene (scene index 1 in this case)
    public void goNext()
    {
        SceneManager.LoadScene(1); // Load the scene with index 1
    }

    // Update is called once per frame
    void Update()
    {
        // Check if spawnedObject is assigned
        if (spawnedObject != null)
        {
            // Find the GameObject named "Current Avatar" in the scene
            TransportedObject = GameObject.Find("Current Avatar");

            // If the GameObject named "Current Avatar" is found
            if (TransportedObject != null)
            {
                // Set the position of TransportedObject to match the position of spawnedObject
                TransportedObject.transform.position = new Vector3(
                    spawnedObject.transform.position.x,
                    spawnedObject.transform.position.y,
                    spawnedObject.transform.position.z
                );
            }
        }
    }
}
