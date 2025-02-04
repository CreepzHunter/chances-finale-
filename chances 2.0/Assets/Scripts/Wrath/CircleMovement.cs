using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Transform spawnPoint; 
    public Transform positionA;
    public Transform positionB;
    private bool isRotating = false; 
    private bool isClockwise = false; 
    private bool isAtPositionA = true;  
   private bool canTeleport = true;  
    [SerializeField] private float teleportCooldown = 0.5f; 

    public GameManagerWrath gameManagerWrath;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isRotating)
            {
                isRotating = true; 
            }
            else
            {
                isClockwise = !isClockwise; 
            }
        }

        if (isRotating)
        {
            RotateCircle();
            MoveCircle();
        }
                MoveCamera();

    }

    private void RotateCircle()
    {
        float direction = isClockwise ? 1f : -1f; 
        transform.Rotate(0f, 0f, rotationSpeed * direction * Time.deltaTime);
    }

    private void MoveCircle()
    {
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
    }

     private void MoveCamera()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = spawnPoint.position;
        }
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            // Win game logic here
            Debug.Log("You Win!");
            gameManagerWrath.ReturnAll();
        }
         if (collision.gameObject.CompareTag("switch") && canTeleport)
        {
            canTeleport = false; 

            float distanceToA = Vector2.Distance(transform.position, positionA.position);
            float distanceToB = Vector2.Distance(transform.position, positionB.position);

            if (distanceToA < distanceToB)  
            {
                transform.position = positionB.position;  
            }
            else  
            {
                transform.position = positionA.position;  
            }

            Invoke(nameof(ResetTeleport), teleportCooldown);
        }
    }

    private void ResetTeleport()
    {
        canTeleport = true;  
    }


}