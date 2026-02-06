using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float xRange = 10f;

    public GameObject foodPrefabs;
    private InputAction moveAction;
    private InputAction ShootAction;

    Vector3 originalCameraPos;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        ShootAction = InputSystem.actions.FindAction("Shoot");

        moveAction?.Enable();
        ShootAction?.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate((hInput * speed * Time.deltaTime) * Vector3.right);

        if (transform.position.x < -10f)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > 10f)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (ShootAction.triggered)
        {
            Instantiate(foodPrefabs, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Vector3 left = new Vector3(-xRange, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(xRange, transform.position.y, transform.position.z);
        Gizmos.DrawLine(left, right);

        Gizmos.color= Color.green;
        Gizmos.DrawWireSphere(left, 1f);
        Gizmos.DrawWireSphere(right, 1f);
    }
}
