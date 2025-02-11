using UnityEngine;

public class ArmAim : MonoBehaviour
{
    public Transform arm; // The arm to rotate
    public bool useMouse = false; // Toggle between mouse and controller input
    public float rotationSpeed = 5.0f;
void Update()
{
    if (arm == null)
    {
        Debug.LogError("Arm Transform is not assigned!");
        return;
    }

    Vector3 direction;

    if (useMouse)
    {   
        Vector3 mousePosition = Input.mousePosition;
        direction = mousePosition - arm.position;
    }
    else
    {
        float horizontal = Input.GetAxis("RightStickHorizontal");
        float vertical = -Input.GetAxis("RightStickVertical");
        direction = new Vector3(horizontal, vertical, 0);
    }

    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    // Rotate the arm based on the angle and speed
    Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    arm.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    // arm.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
}}