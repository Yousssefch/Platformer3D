using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public float forwardforce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("player"))
        {
            rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
            rb.AddForce(rb.transform.up*jumpForce,ForceMode.Impulse);
            Debug.Log("true");
        }
    }
}
