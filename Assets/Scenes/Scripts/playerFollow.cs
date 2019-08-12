using UnityEngine;

public class playerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 camOffset;
    
    

    // Update is called once per frame
    public void FixedUpdate()
    {
        
        {
            transform.position = player.position + offset;
        } 
    }

    


}
