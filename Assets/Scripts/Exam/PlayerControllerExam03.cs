using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed = 10.0f;
    public float xRange = 10.0f;
    public GameObject projectilePrefab;


    public bool enableAutoFireMode;
    public float autoFireInterval = 0.5f;
    private float nextFireTime;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {

        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


        if (transform.position.x < -xRange) transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange) transform.position = new Vector3(xRange, transform.position.y, transform.position.z);


        if (enableAutoFireMode)
        {

            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                nextFireTime = Time.time + autoFireInterval;
            }
        }
        else if (shootAction.triggered)
        {

            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Instantiate(projectilePrefab, transform.position, transform.rotation);
    }
}