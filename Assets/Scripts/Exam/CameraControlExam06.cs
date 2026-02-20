using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Camera targetCamera;

    [Header("Camera Settings")]
    public float minSize = 5f;
    public float zoomFactor = 1.5f;
    public Vector3 offset = new Vector3(0, 10, 0);

    void LateUpdate()
    {
        if (player1 == null || player2 == null || targetCamera == null) return;

        Move();
        Zoom();
    }

    void Move()
    {
        Vector3 midpoint = (player1.position + player2.position) / 2f;
        transform.position = midpoint + offset;
    }

    void Zoom()
    {

        float distance = Vector3.Distance(player1.position, player2.position);
        targetCamera.orthographicSize = minSize + (distance / zoomFactor);
    }
}