using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    Rigidbody rb;
    public Transform oriontation;

    public int mouvspeed;
    float inputHorizontal;
    float inputVertical;
    public float playerheight;
    public LayerMask ground;
    bool grounded;
    public float dragGround;
    public float airDrag;
    Vector3 mouvDirection;

    public float jumpForce;
    public float airController;
    bool isJump;
    public float airdash;

    public int DashSpeed;
    int defaultSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultSpeed = mouvspeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.Raycast(transform.position,Vector3.down,playerheight*0.5f+0.2f,ground);


        MyInput();

        
        SpeedControl();

        if (grounded)
        {
            rb.drag = dragGround;
            isJump = true;
        }
        else
        {
            rb.drag = airDrag;
            
        }
        Jump();
        Dash();
    }
    private void FixedUpdate(){
        MouvePlayer();
    }

    private void MyInput(){
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

    }

    private void Jump(){
        if (grounded&& Input.GetKey(KeyCode.Space)&&isJump)
        {
            rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
            rb.AddForce(transform.up*jumpForce,ForceMode.Impulse);
            isJump = false;
        }
    }

    private void SpeedControl(){
        Vector3 flatvel = new Vector3(rb.velocity.x,0f,rb.velocity.z);
        if (flatvel.magnitude > mouvspeed)
        {
            Vector3 limitedvel =flatvel.normalized*mouvspeed;
            rb.velocity = new Vector3(limitedvel.x,rb.velocity.y,limitedvel.z);
        }
    }
    private void MouvePlayer(){
        mouvDirection = oriontation.forward * inputVertical + oriontation.right * inputHorizontal;
        if (grounded)
        {
           rb.AddForce(mouvDirection.normalized * mouvspeed*10f, ForceMode.Force); 
        }
        else
        {
            rb.AddForce(mouvDirection.normalized * mouvspeed*10f*airController, ForceMode.Force);
        }

        

    }

    private void Dash(){
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(grounded){
            mouvspeed = DashSpeed;
            }
        }
        else
        {
            mouvspeed = defaultSpeed;
        }
    }
    
}
