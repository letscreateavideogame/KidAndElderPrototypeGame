using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedFoward = 15f;
    public float Lateral = 15f;
    public int forceConst = 5;
    public Rigidbody rb;
    private bool canJump;
    public float horizontalSpeed = 200F;
    private float distToGround;
    RaycastHit hit;
    public float speed = 15;
    public float jumpSpeed = 5f;
    public float characterHeight = 2f;
    private Transform myTransform;
    float jumpRest = 0.05f; // Sets the ammount of time to "rest" between jumps
    float jumpRestRemaining = 0; //The counter for Jump Rest

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * SpeedFoward * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * Lateral * Time.deltaTime);     
        if (canJump)
        {
            canJump = false;
            jumpRestRemaining = jumpRest; // Resets the jump counter
            rb.AddRelativeForce(Vector3.up * jumpSpeed * 100); // Adds upward force to the character multitplied by the jump speed, multiplied by 100
        }
    }
    void Update()
    {
        jumpRestRemaining -= Time.deltaTime;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            distToGround = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.cyan);
        }
         if (Input.GetButtonDown("Jump") && distToGround < (characterHeight * .5) && jumpRestRemaining < 0)
        { // If the jump button is pressed and the ground is less the 1/2 the hight of the character away from the character.
            canJump = true;
        }
        float h = horizontalSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.Rotate(0, h, 0);
    }
}

