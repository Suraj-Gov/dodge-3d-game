using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float horspeed = 10f;
    public float vertspeed = 12f;
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
    
    public bool invin = false;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = Mats[0];
    }

    public void FixedUpdate()
    {
        
        float xmovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * horspeed;
        float ymovement = Input.GetAxis("Vertical") * Time.fixedDeltaTime * vertspeed;
        Vector3 MovementVector = rb.position + Vector3.right * xmovement + Vector3.forward * ymovement;
        MovementVector.x = Mathf.Clamp(MovementVector.x, -5.5f, 5.5f);
        MovementVector.z = Mathf.Clamp(MovementVector.z, 8.24f, 20.24f);
        
        
        

        rb.position = MovementVector;

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


        if(collisionInfo.collider.tag == "Obstacle" && invin == true)
        {
            collisionInfo.gameObject.GetComponent<BoxCollider>().enabled = false;
        }


        if (collisionInfo.collider.tag =="Obstacle" && invin == false)
        {


            Vector3 playerPos = player.transform.position;
            GameObject brokenPlayer = Instantiate(broken, playerPos, Quaternion.identity) as GameObject;
            brokenPlayer.GetComponent<BoxCollider>().enabled = true;
            broken.transform.position = Vector3.up * 10000f + Vector3.forward * -10000f ;
            //Debug.Log("1.1");


            
            {
                playerCollider.enabled = false;
                playerMesh.enabled = false;


                FindObjectOfType<gameState>().endGame();
            }
            
        }

        
 
    }

    public void JumpEffect()
    {
        GameObject eject = Instantiate(ejectStuff, ejectorPlace.transform.position, Quaternion.identity);
        eject.GetComponent<Rigidbody>().AddForce(0f, 10f, -5f, ForceMode.Impulse);
        transform.localScale = transform.localScale * 0.95f;
    }

    

    public void enableInvin()
    {
        invin = true;
    }

    public void disableInvin()
    {
        invin = false;
    }


    


}

