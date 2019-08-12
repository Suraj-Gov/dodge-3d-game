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

    
}
