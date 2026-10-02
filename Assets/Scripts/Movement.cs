using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float sidedistance = 3f;
    public float jumpForce = 5f;
    public float sideSpeed = 1f;
    public float gravity = 9.81f;
    public bool isjumping = false;
    private int currentLane = 1;
    private float verticalVelocity = 0f;
    private float groundY;
    private float startX;
    //public ParticleSystem movementLines;
    public float high;

    void Start()
    {
        startX = transform.position.x;
        groundY = transform.position.y;
    }
    void Update()
    {
        if (GameManager.instance.isPaused)
            return;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        HandleslideMovement();
        HandleJump();

        //GetComponent<Animator>().SetBool("Jump", isjumping);
    }
    public void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
            //GetComponent<Animator>().SetTrigger("Left");
            //movementLines.transform.localRotation = Quaternion.Euler(0, 90, 0);
            //movementLines.Play();
        }
    }
    public void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
            //GetComponent<Animator>().SetTrigger("Right");
            //movementLines.transform.localRotation = Quaternion.Euler(0, -90, 0);
            //movementLines.Play();
        }
    }
    public void Jump()
    {
        if (isjumping) return;

        
        verticalVelocity = jumpForce;
        isjumping = true;
        GetComponent<Animator>().SetBool("Jump", true);
    }
    void HandleslideMovement()
    {
        float targetX = startX + (currentLane -1) * sidedistance;
        float newX = Mathf.MoveTowards(transform.position.x, targetX, sideSpeed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
    void HandleJump()
    {
        verticalVelocity -= gravity * Time.deltaTime * high;
        float newY = transform.position.y + verticalVelocity * Time.deltaTime;
        if (newY <= groundY)
        {
            newY = groundY;
            verticalVelocity = 0f;
            isjumping = false;
            //GetComponent<Animator>().SetBool("Jump", false);
        }
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
