using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float turning_speed;
    public Camera player_camera;
    public Camera floating_camera;

    private Rigidbody player_rb; 

    private float movementX;
    private float movementY;

    public float speed = 0;

    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        floating_camera.enabled = false;
    }
 

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    private void Update()
    {
        // Kamerawechsel
        if (Input.GetButtonDown("Jump"))
        {
            player_camera.enabled = !player_camera.enabled;
            floating_camera.enabled = !floating_camera.enabled;
        }
    }

    private void FixedUpdate() 
    {
        if(!player_camera.enabled)
        {
            return;
        }
        // WASD und Pfeiltasten
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        movement = Quaternion.Euler(transform.rotation.eulerAngles) * movement;
        player_rb.AddForce(movement * speed * Time.deltaTime, ForceMode.VelocityChange);
        if (movement.magnitude == 0)
        {
            player_rb.linearVelocity = new Vector3(0, player_rb.linearVelocity.y, 0);
        }

        // Maus
        float x = Input.GetAxis("Mouse X") * Time.deltaTime * turning_speed;
        float y = -1 * Input.GetAxis("Mouse Y") * Time.deltaTime * turning_speed;

        x += transform.rotation.eulerAngles.y;
        y += player_camera.transform.localRotation.eulerAngles.x;
        if (y > 180) {y -= 360;}
        y = Mathf.Clamp(y, -85f, 85f);

        // Spieler
        transform.rotation = Quaternion.Euler(0, x, 0);

        // Kamera
        player_camera.transform.localRotation = Quaternion.Euler(y, 0, 0);
    }

}