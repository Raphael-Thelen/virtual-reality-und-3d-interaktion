using UnityEngine;

public class WarpTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        GameObject colliding_object = other.gameObject;
        if (colliding_object.CompareTag("Player"))
        {
            colliding_object.transform.position += new Vector3(0, 14, -32);
        }
    }
}
