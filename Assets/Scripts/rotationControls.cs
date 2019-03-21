using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationControls : MonoBehaviour
{
    public GameObject player;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    [HideInInspector]
    public float yaw = 0.0f;
    public float pitch = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerUpgradeSystem>().open == false) {
            transform.position = player.transform.position;
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
