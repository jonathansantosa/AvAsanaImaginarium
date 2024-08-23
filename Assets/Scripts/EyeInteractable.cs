using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EyeInteractable : MonoBehaviour
{
    // Property to indicate if the object is currently being hovered over
    public bool IsHovered { get; set; }

    // UnityEvent to call when the object is hovered over, with the GameObject as a parameter
    [SerializeField] private UnityEvent<GameObject> OnObjectHover;

    // Materials for different hover states
    [SerializeField] private Material OnHoverActiveMaterial;
    [SerializeField] private Material OnHoverInactiveMaterial;

    private MeshRenderer meshRenderer; // Reference to the MeshRenderer component

    // Start is called before the first frame update
    void Start()
    {
        // Get the MeshRenderer component attached to this GameObject
        meshRenderer = GetComponent<MeshRenderer>();

        // If no material is set for hover active state, use the current material
        if(OnHoverActiveMaterial == null)
            OnHoverActiveMaterial = meshRenderer.material;

        // If no material is set for hover inactive state, use the current material
        if(OnHoverInactiveMaterial == null)
            OnHoverInactiveMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHovered)
        {
            // Change material to active hover material and invoke the hover event
            meshRenderer.material = OnHoverActiveMaterial;
            OnObjectHover?.Invoke(gameObject); // Invoke the event if it has subscribers
        }
        else
        {
            // Change material to inactive hover material when not hovered
            meshRenderer.material = OnHoverInactiveMaterial;
        }
    }
}
