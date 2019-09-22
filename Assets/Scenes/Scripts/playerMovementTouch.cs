using UnityEngine;
using UnityEngine.UI;

public class playerMovementTouch : MonoBehaviour
{
    public GameObject player;
    public Rigidbody player_rb;
    private float screenWidth;
    private float speed;



    public void Start()
    {
        screenWidth = Screen.width;
        speed = PlayerPrefs.GetFloat("moveSpeed", 210f);
        
        
    }
    public void Update()
    {
        
        int i = 0;
        while(i < Input.touchCount)
        {
            if(Input.GetTouch(0).position.x > screenWidth/1.5f)
            {
                player_rb.AddForce(speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            else if(Input.GetTouch(0).position.x < screenWidth/2.4f)
            {
                player_rb.AddForce(-speed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            ++i;
        }

     
    }

    public void FixedUpdate()
    {
        Vector3 movement = player_rb.position;
        movement.x = Mathf.Clamp(movement.x, -5.41f, 5.41f);
        player_rb.position = movement;
    }

    

    


}
