using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float minX = -10.0f;
    public float maxX = 10.0f;
    public float minY = -5.0f;
    public float maxY = 5.0f;

    void Update()
    {
        float horizontalInput = -Input.GetAxis("Horizontal") * sensitivity * Time.deltaTime;
        float verticalInput = -Input.GetAxis("Vertical") * sensitivity * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(horizontalInput, verticalInput, 0);
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}
