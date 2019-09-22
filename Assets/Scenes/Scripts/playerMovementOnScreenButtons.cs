using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovementOnScreenButtons : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    void Start()
    {
        speed = PlayerPrefs.GetFloat("moveSpeed", 150f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMovement = CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        Vector3 movement = rb.position + Vector3.right * xMovement;
        rb.position = movement;
    }
}
