using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoGoEnemyBulletBill : MonoBehaviour
{
    public GameObject player;
    private int bulletSpeed = 40;
    private string type;
    private float killTime = 0;
    private float damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(this.type=="Fighter")
            transform.LookAt(player.transform);
        //transform.rotation = player.transform.rotation;
    }
    public void startMoving(int going, float damage, string type)
    {
        this.type = type;
        this.bulletSpeed = going;
        this.damage = damage;
        this.killTime = Mathf.Floor(Time.time) + 3f;
        this.move = true;
    }
    // Update is called once per frame
    private bool move = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Floor") {
           Destroy(gameObject);
        }
        if (other.tag == "Player") {
            Debug.Log("Player was hit!!!");
           Destroy(gameObject);
        }
    }

    void Update()
    {  
        if (this.move == true) {
            if (this.killTime == Mathf.Floor(Time.time)) {
                Destroy(this.gameObject);
            }
            transform.position += transform.forward * Time.deltaTime * bulletSpeed;
        }
    }
}
