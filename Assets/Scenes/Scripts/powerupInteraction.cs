using System.Collections;
using System.Collections.Generic;   //needed for IEnumerator
using UnityEngine;
//further code development required for this to be eligible for commentation
public class powerupInteraction : MonoBehaviour
{
    
    public Color sizeIncreaseColor; 
    
    public Color invinColor;
    public Color healthPlus;
    public Color normalColor;
    
    public GameObject playerCube;

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

        float elapsedTime = 0f;
        float totalTime = 0.5f;

        while(elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            playerCube.GetComponent<Renderer>().material.color = Color.Lerp(normalColor, invinColor, elapsedTime/totalTime*2);
            yield return null;
        }



        yield return new WaitForSeconds(3f);

        elapsedTime = 0f;
        totalTime = 0.5f;

        while(elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            playerCube.GetComponent<Renderer>().material.color = Color.Lerp(invinColor, normalColor, elapsedTime/totalTime);
            yield return null;
        }

        
        FindObjectOfType<playerMovement>().disableInvin();
    }

    


}
