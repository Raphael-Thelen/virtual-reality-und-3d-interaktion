using UnityEngine;

public class ColorToggle : MonoBehaviour
{
    public Renderer targetRenderer; // Assign in Inspector
    public Color colorA = Color.red;
    public Color colorB = Color.blue;

    private bool useColorA = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Toggle the color
            useColorA = !useColorA;
            targetRenderer.material.color = useColorA ? colorA : colorB;
        }
    }
}
