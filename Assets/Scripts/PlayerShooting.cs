using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject wand;
    private float cooldown = 0;
    public float cooldownInc = 1f;
    public int bulletspeed = 50;
    public float damage = 5;
    public int projectiles = 1;
    public float animSpeed = 1f;
    private bool delayPlay;
    private GameObject camera;

   // [HideInInspector]
    public bool pierce = false;

    private float buffer;
    // Start is called before the first frame update
    void Start()
    {
        camera = gameObject.GetComponent<PlayerMovement>().camera;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerUpgradeSystem>().open == false) {
            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Slash) || Input.GetMouseButtonDown(0)) {
                if (Time.time >= cooldown) {
                    delayPlay = true;
                    buffer = Time.time + 0.3f / animSpeed; // basically an arbitrary number.  
                    cooldown = Time.time + cooldownInc;
                    wand.GetComponent<Animator>().SetTrigger("Fire");
                    wand.GetComponent<Animator>().speed = animSpeed;
                }
            }
        }
        if (Time.time >= buffer && delayPlay == true) {
            delayPlay = false;
            if (this.projectiles>1) {
                float rotationOffset = -30;
                float rotatorControl = 30 / this.projectiles;
                for (int i = 0; i < this.projectiles; i++) {
                    GameObject temp = Instantiate(bullet, transform.position, camera.transform.rotation);
                    //temp.transform.eulerAngles = new Vector3(camera.transform.rotation.x,camera.transform.rotation.y,camera.transform.rotation.z);
                    rotationOffset = (rotatorControl / 2) * (i - Mathf.FloorToInt(this.projectiles / 2));
                    temp.transform.Rotate(0, rotationOffset, 0);
                    temp.GetComponent<GoGoBulletBill>().startMoving(bulletspeed, damage);
                }
            }
            if (this.projectiles==1) {
                GameObject temp = Instantiate(bullet, transform.position, camera.transform.rotation);
                temp.GetComponent<GoGoBulletBill>().startMoving(bulletspeed, damage);
            }
        }
    }
}
