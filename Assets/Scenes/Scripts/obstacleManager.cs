using UnityEngine;

public class obstacleManager : MonoBehaviour
{

    
    public void FixedUpdate()
    {
        if (transform.position.y <= -1f)
        {
            Destroy(gameObject);   
        }
    }   
        //used to eliminate the obstacles when they drop below the level
        //linked to the Obstacle
}
