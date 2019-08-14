using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletePowerups : MonoBehaviour
{
    
    void Update()
    {
        if(transform.position.z < 0f)
        {
            Destroy(gameObject);
        }
    }
}
