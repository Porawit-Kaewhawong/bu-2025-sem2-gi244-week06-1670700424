using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam02 : MonoBehaviour
{
    public float speed;
    public float zRange = 10;
    public GameObject projectilePrefab;

    private float verticalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = moveAction.ReadValue<Vector2>().y;

        // Move vertically
        transform.Translate(Vector3.left * verticalInput * Time.deltaTime * speed);

        // Limit walkable area
        if (transform.position.z >= zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z <= -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        // Shoot
        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
