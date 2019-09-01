using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float horspeed = 10f;            //horizontal movement sensitivity
    public Rigidbody rb;                    //rb is the rigidbody linked to the playerGameObject
    public bool isGround;                   //verifies if the player is grounded
    public GameObject broken;               //just the disintegrated player model
    public GameObject player;               //player model
    public BoxCollider playerCollider;      //player's box collider
    public MeshRenderer playerMesh;         //player's mesh renderer
    Vector3 playerPos;                      //has value equal to player's position in real time
    public float jumpForce;                 //the force with which the player jumps
    public float fallHigh;                  //when the player holds the jump
    public float fallLow;                   //when the player just taps the jump
    public GameObject ejectStuff;           //the block that's ejected when the player jumps
    public GameObject ejectorPlace;         //the place from where the ejected block must exit
    public Renderer rend;                   //used to getcomp the renderer for the player material
    public Material[] Mats;                 //array of the colors which indicates the player state/size
    public GameObject brokenObst;
    public bool invin = false;              //invincibility boolean which is defaulted to false

    public void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = Mats[0];
        //initializes the material to start with bright red to indicate that player is optimal in size
    }


    public void Update()
    {
        

        if (Input.GetButtonDown("Jump") && isGround == true)    //jump script
        {
            JumpNow();
            
        }

        if (rb.velocity.y < 0 && Input.GetButton("Jump"))
        {
            rb.velocity = Vector3.up * Physics.gravity.y * (fallHigh - 1) * Time.fixedDeltaTime;
            //code for better jump
            //when held, jump is at high level and comes down quick
        }
        if (rb.velocity.y < 0 && !Input.GetButton("Jump"))
        {
            rb.velocity = Vector3.up * Physics.gravity.y * (fallLow - 1) * Time.fixedDeltaTime;
            //when tapped, jump is at mid level and comes down quick
        }
    }
    public void FixedUpdate()
    {

        float xmovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * horspeed; //InputValue * horzSensit
        Vector3 MovementVector = rb.position + Vector3.right * xmovement;
        //this encapsulates the position with movement position into one vector
        MovementVector.x = Mathf.Clamp(MovementVector.x, -5.5f, 5.5f);      //clamps the Xax movement
        MovementVector.z = Mathf.Clamp(MovementVector.z, 8.24f, 20.24f);    //clamps the Yax movement
        rb.position = MovementVector;   //equates that one movement vector to position of the player

        

        if(transform.localScale.x < 0.4f)
        {
            rend.sharedMaterial = Mats[2];  //changes color to show danger color because size very small
        }
        else if(transform.localScale.x < 0.6f && transform.localScale.x > 0.4f)
        {
            rend.sharedMaterial = Mats[1];  //changes color to warning color because size is small
        }

        

    }

    public void OnCollisionEnter(Collision collisionInfo)
        // the cool/frustrating stuff
    {
        if (collisionInfo.collider.tag == "Ground" && isGround == false)
        {
            isGround = true;
            //checks if player is grounded, if false, when player hits ground, isGround bool is true.
        }


        if(collisionInfo.collider.tag == "Obstacle" && invin == true)
        {
            GameObject broke = Instantiate(brokenObst, collisionInfo.collider.transform.position, collisionInfo.collider.transform.rotation);
            Destroy(collisionInfo.collider.gameObject);
            broke.GetComponent<Rigidbody>().AddForce(0, 500f, -5f, ForceMode.Impulse);
            //when the player is in invincible mode, when hit by a obstacle, obstacle's collider is disabled
        }


        if (collisionInfo.collider.tag =="Obstacle" && invin == false || transform.localScale.x < 0.3f)
            //when player hits the obstacle in normal vurnerable condition
        {

            Vector3 playerPos = player.transform.position;  //player position is recorded in this vector
            GameObject brokenPlayer = Instantiate(broken, playerPos, Quaternion.identity) as GameObject;
            //broken.transform.position = Vector3.up * 10000f + Vector3.forward * -10000f;
            //add this line to make the disintegrated cubes more explosive-like
                     
            {
                playerCollider.enabled = false;     //actually, you cannot destroy player.
                playerMesh.enabled = false;     //but you can hide the player from existence
                
                //here the mesh and collider is disabled to mimic the absense of player.
                FindObjectOfType<gameState>().endGame();    //calls the function to end the game
            }
            
        }

        
 
    }

    public void JumpEffect()
    {
        GameObject eject = Instantiate(ejectStuff, ejectorPlace.transform.position, Quaternion.identity);
        eject.GetComponent<Rigidbody>().AddForce(0f, 10f, -5f, ForceMode.Impulse);
        transform.localScale = transform.localScale * 0.95f;
        //ejects a piece of cube from the player's behind, adds an impulse force so that it has the effect of
        //emisson due to jump, then the scale of the player is lowered by 5%
    }

    

    public void enableInvin()
    {
        invin = true;   //this enables the invincible boolean to true, needed for the coroutine in interaction code
    }

    public void disableInvin()
    {
        invin = false;  //this disables the invincible boolean to false, when called after set duration from coroutine
    }

    public void JumpNow()
    {
        if (isGround == true)
        {
            rb.velocity = Vector3.up * jumpForce;   //adds jumpForce to the Yax of player
            isGround = false;  //sets isGround to false, because player is off ground when jumped
            JumpEffect();   //calls the jump effect to emit the eject block from player's behind
        }
    }
}