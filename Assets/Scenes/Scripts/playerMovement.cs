using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float horspeed = 10f;
    public Rigidbody rb;
    public bool isGround;
    public GameObject broken;
    public GameObject player;
    public BoxCollider playerCollider;
    public MeshRenderer playerMesh;
    Vector3 playerPos;
    public float jumpForce;
    public float fallHigh;
    public float fallLow;
    public GameObject ejectStuff;
    public GameObject ejectorPlace;
    public Renderer rend;
    public Material[] Mats;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = Mats[0];
    }

    public void FixedUpdate()
    {
        float xmovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * horspeed;
        Vector3 xMovementVector = rb.position + Vector3.right * xmovement;
        rb.position = xMovementVector;

        xMovementVector.x = Mathf.Clamp(xMovementVector.x, -5.5f, 5.5f);

        rb.position = xMovementVector;

        if(Input.GetButtonDown("Jump") && isGround == true)
        {
            rb.velocity = Vector3.up * jumpForce;
            isGround = false;
            JumpEffect();
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity = Vector3.up * Physics.gravity.y * (fallHigh  - 1) * Time.fixedDeltaTime;
        }
        if(rb.velocity.y < 0 && !Input.GetButton("Jump") )
        {
            rb.velocity = Vector3.up * Physics.gravity.y * (fallLow  - 1) * Time.fixedDeltaTime;
        }
        
        if(transform.localScale.x < 0.3f)
        {
            FindObjectOfType<gameState>().endGame();
        }

        if(transform.localScale.x < 0.4f)
        {
            rend.sharedMaterial = Mats[2];
        }
        else if(transform.localScale.x < 0.5f)
        {
            rend.sharedMaterial = Mats[1];
        }


    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground" && isGround == false)
        {
            isGround = true;
        }

        if(collisionInfo.collider.tag =="Obstacle" || transform.localScale.x < 0.3)
        {


            Vector3 playerPos = player.transform.position;
            GameObject brokenPlayer = Instantiate(broken, playerPos, Quaternion.identity) as GameObject;
            playerCollider.enabled = false;
            playerMesh.enabled = false;
    
            FindObjectOfType<gameState>().endGame();    
        }
 
    }

    public void JumpEffect()
    {
        GameObject eject = Instantiate(ejectStuff, ejectorPlace.transform.position, Quaternion.identity);
        eject.GetComponent<Rigidbody>().AddForce(0f, 5f, -5f, ForceMode.Impulse);
        transform.localScale = transform.localScale * 0.95f;
    }



    


}

