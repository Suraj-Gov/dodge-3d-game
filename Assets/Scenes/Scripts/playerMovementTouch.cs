using UnityEngine;
using UnityEngine.UI;

public class playerMovementTouch : MonoBehaviour
{
    public GameObject player;
    public Rigidbody player_rb;
    private float screenWidth;
    public float speed;
    

    


    public void Start()
    {
        screenWidth = Screen.width;
        speed = PlayerPrefs.GetFloat("moveSpeed", 270000f);
        
        
    }
    public void Update()
    {
        
        int i = 0;
        while(i < Input.touchCount)
        {
            if(Input.GetTouch(0).position.x > screenWidth/1.5f)
            {
                player_rb.AddForce(1f * speed * Time.deltaTime, 0f, 0f, ForceMode.Impulse);
            }
            else if(Input.GetTouch(0).position.x < screenWidth/2.4f)
            {
                player_rb.AddForce(-1f * speed * Time.deltaTime, 0f, 0f, ForceMode.Impulse);
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
