using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // the character to follow
    [SerializeField] private float smoothing; // the smoothing value for the camera movement
    private Vector3 startPos; // the starting position of the camera

    private Vector3 offset;
    private Vector3 followOffset;
    float moveThresShold = 0.1f;

    private void Start()
    {
        // Calculate the initial offset between the camera and the target
        offset = transform.position - target.position;
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        float moveDistance = target.position.x - transform.position.x;
        // Only follow the character towards the right
        if (moveDistance < moveThresShold)
        {
            // Calculate the target position based on the offset and target's current position
            Vector3 targetCamPos = target.position + offset;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }

    public void ResetCamera()
    {
        // Reset the camera position to its starting position
        transform.position = startPos;
    }
}