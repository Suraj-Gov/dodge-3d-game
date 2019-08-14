using UnityEngine;

public class playerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    public void FixedUpdate()
    {   //simple script that tells the camera to stay behind the player
        //like a third person shooter perspective
        
        {
            transform.position = player.position + offset;
            //player positon plus the offset values
        } 
    }

    


}
