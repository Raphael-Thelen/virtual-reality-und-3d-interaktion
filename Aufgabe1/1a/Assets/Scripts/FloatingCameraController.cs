using UnityEngine;

public class FloatingCameraController : MonoBehaviour
{
    public float speed;
    public float turning_speed;
    public Camera floating_camera;

    private float movementX;
    private float movementY;

    // Update is called once per frame
    void Update()
    {
        if(!floating_camera.enabled)
        {
            return;
        }
        // WASD und Pfeiltasten
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY) * speed  * Time.deltaTime;
        movement = Quaternion.Euler(transform.rotation.eulerAngles) * movement;
        transform.position += movement;

        // Maus
        float x = Input.GetAxis("Mouse X") * Time.deltaTime * turning_speed;
        float y = -1 * Input.GetAxis("Mouse Y") * Time.deltaTime * turning_speed;

        x += transform.rotation.eulerAngles.y;
        y += transform.rotation.eulerAngles.x;

        transform.rotation = Quaternion.Euler(y, x, 0);
    }
}
