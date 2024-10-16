using System.Collections.Generic;
using UnityEngine;

public class YourClass : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask ground;
    public LayerMask cubeFilter;

    private Dictionary<Collider, Color> originalColors = new Dictionary<Collider, Color>();

    private void FixedUpdate()
    {
        // Raycast
        float distance = 10;

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, distance, ground))
        {
            distance = hit.distance;
        }

        Vector3 camPos = playerCamera.transform.position;
        Debug.DrawLine(camPos, camPos + playerCamera.transform.forward * 10);

        RaycastHit[] hits = Physics.RaycastAll(playerCamera.transform.position, playerCamera.transform.forward, distance, cubeFilter);

        // Reset colors for all cubes that are not currently being hit
        ResetColors(hits);

        foreach (RaycastHit hit2 in hits)
        {
            if (hit2.collider.TryGetComponent(out Renderer renderer))
            {
                if (!originalColors.ContainsKey(hit2.collider))
                {
                    // Store original color
                    originalColors[hit2.collider] = renderer.material.color;
                }

                // Change color to red
                renderer.material.color = Color.red;
                Debug.Log($"Hit {hits.Length} cubes");
                Debug.Log($"Distance is {distance} from the cube");
            }
        }
    }


    // Resets colors of highlighted raycast object (cube)

    private void ResetColors(RaycastHit[] hits)
    {
        // Create a HashSet of current hit colliders
        HashSet<Collider> currentHitColliders = new HashSet<Collider>();
        foreach (var hit in hits)
        {
            currentHitColliders.Add(hit.collider);
        }

        // Reset color for all original tracked colors not currently hit
        foreach (var entry in originalColors)
        {
            if (!currentHitColliders.Contains(entry.Key))
            {
                if (entry.Key.TryGetComponent(out Renderer renderer))
                {
                    renderer.material.color = entry.Value; // Reset to original color
                }
            }
        }
    }
}


