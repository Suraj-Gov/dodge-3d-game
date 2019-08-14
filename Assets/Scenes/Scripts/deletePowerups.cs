using UnityEngine;

public class deletePowerups : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.z < 2f)
        {
            //could instantiate a powerupdestroy effect
            Destroy(gameObject);
            //if powerup goes at certain position, they are deleted.
        }
    }
}
