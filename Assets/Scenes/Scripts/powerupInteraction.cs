using System.Collections;
using System.Collections.Generic;   //needed for IEnumerator
using UnityEngine;
//further code development required for this to be eligible for commentation
public class powerupInteraction : MonoBehaviour
{
    
    public Color sizeIncreaseColor; 
    public Color blankWhite;
    public Color invinColor;
    public Color healthPlus;
    public Color normalColor;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "powerupSizePlus")
        {
            SizeIncrease();
            Destroy(other.gameObject);
        }

        else if(other.tag == "powerupInvin")
        {
            StartCoroutine(Invin());
            Destroy(other.gameObject);
        }

        
    }

    public void SizeIncrease()
    {
        transform.localScale *= 1.2f;
        

    }

    IEnumerator Invin()
    {
        FindObjectOfType<playerMovement>().enableInvin();

        yield return new WaitForSeconds(3f);
        Debug.Log("end invin");
        FindObjectOfType<playerMovement>().disableInvin();
    }

    


}
