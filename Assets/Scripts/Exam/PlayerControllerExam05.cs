using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    private int currentBulletCount = 0;
    public float bulletRegenerateCooldown = 1f;
    // ...
    private float lastBulletTime;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentBulletCount = maxBulletCount;
        lastBulletTime = bulletRegenerateCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            if (currentBulletCount > 0)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                currentBulletCount--;
                Debug.Log(currentBulletCount);
            }

            if (currentBulletCount <= 0)
            {
                
                reload();
            }
            
        }
    }

    public void reload()
    {
        Debug.Log("Reload");
        float time = Time.time;
        Debug.Log(time);
        if (time >= lastBulletTime)
        {
            currentBulletCount = maxBulletCount;
            lastBulletTime = Time.time+bulletRegenerateCooldown;
            
        }
    }
}
