using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 positionUpdate;
    CharacterController CController;
    public GameObject camera;
    private CapsuleCollider Colid;
    private Rigidbody rb;
    public int gravity = 5;
    private bool grounded = false;
    bool offsetCheck = true;
    float moveMult = 10F;


    [HideInInspector]
    public float yaw = 0.0f;
    public float speedH = 2.0f;

    //private Animator Anim; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        //Anim = GetComponent<Animator>();
        CController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        Colid = GetComponent<CapsuleCollider>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor") {
            grounded = true;
        }
            
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Floor") {
            grounded = false;
        }
    }
    // Update is called once per frame
    public void cursorOn()
    {
        Cursor.visible = true;
    }
    public void cursorOff()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        //int moving;
        // Movement controls
         if (gameObject.GetComponent<PlayerUpgradeSystem>().open == false) { 
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                rb.position += (transform.forward * Time.deltaTime * moveMult);
                //transform.position += transform.forward * Time.deltaTime * moveMult;
                //moving = 0;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                rb.position -= transform.forward * Time.deltaTime * moveMult;
                //moving = 1;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                rb.position -= transform.right * Time.deltaTime * moveMult;
                //moving = 0;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                rb.position += transform.right * Time.deltaTime * moveMult;
                //moving = 0;
            }
        // Rotation controls
            yaw += speedH * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0, yaw, 0);
        } 

        // Gravity and jump controls
        if (grounded == true) { 
            if (Input.GetKey(KeyCode.LeftShift)) {
                offsetCheck = false;
                Colid.height = 1f;
            } else if (offsetCheck == false) {
                Debug.Log("it did the thing once");
                Colid.height = 2f;
                Vector3 tempy = rb.position;
                tempy.y = GameObject.Find("Floor").transform.position.y+1.5f;
                rb.position = tempy;
                offsetCheck = true;
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                //Vector3 temp = rb.position;
                //temp.y 
                //rb.position += transform.up*2;
                rb.AddForce(transform.up*5000);
            }
        }
        if (grounded == false) { 
          rb.position -= transform.up * Time.deltaTime *gravity;
        }



        // Zeroes out a bunch of thingamabobs to prevent weird rigidbody things and stuffs
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Quaternion temp = transform.rotation;
        temp.x = 0;
        temp.z = 0;
        rb.rotation = temp;

        //Debug.Log(Mathf.Floor(Time.time));

       
        //↓↓↓ This was the animation stuff ↓↓↓

        //if (moving == 0) {
        //    Anim.SetTrigger("Run");
        //} else if (moving==1) {
        //    Anim.SetTrigger("Backwards");
        //} else {
        //    Anim.SetTrigger("Idle");
        //}


    }
}
