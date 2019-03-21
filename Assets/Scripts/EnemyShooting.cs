using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    private int bulletspeed;
    private float damage;
    private bool active;
    private GameObject player;
    public string type;// Standard, Fighter, AoE, Roller.
    float cooldown;
    float cooldownTimer = 0;
    private int projectiles;
    public bool closeToPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        this.active = false;
        player = GetComponent<EnemyPathfinding>().Player;
        if (type == "Standard") { }// Do Nothing
        if (type == "Fighter") {
            this.cooldown = 2;
            this.damage = 5;
            this.bulletspeed = 20;
        }
        if (type == "AoE") {
            this.cooldown = 3;
            this.damage = 5;
            this.bulletspeed = 10;
            this.projectiles = 8;
        }
        if (type == "Roller") { }// Do Nothing
    }
    public void activate()
    {
        this.active = true;
    }

    // Update is called once per frame
    void Update()
    {
        // to prevent it from shooting before it gets past the gate.
        if (this.active==true) {
            if (this.type == "Standard") { }// Do Nothing
            if (this.type == "Fighter") { // Single fire enemy
                if (Time.time >= cooldownTimer) {
                    if (Vector3.Distance(player.transform.position, transform.position) < 50) { // Checks how far player is from enemy
                        closeToPlayer = true;
                    }
                    if (closeToPlayer) { // fires if close to player
                        cooldownTimer = Time.time + cooldown;
                        GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
                        temp.GetComponent<GoGoEnemyBulletBill>().startMoving(bulletspeed, damage, this.type);
                    }
                }
            }
            if (this.type == "AoE") { 
                if (Time.time >= cooldownTimer) {
                    if (Vector3.Distance(player.transform.position, transform.position) < 50) { // Checks how far player is from enemy
                        closeToPlayer = true;
                    }
                    if (closeToPlayer) { // fires if close to player
                        cooldownTimer = Time.time + cooldown;
                        float rotationOffset = 45;
                        for (int i = 0; i < this.projectiles; i++) {
                            GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
                            temp.transform.Rotate(0, rotationOffset, 0);
                            temp.GetComponent<GoGoEnemyBulletBill>().startMoving(bulletspeed, damage, this.type);
                            rotationOffset += 360 / projectiles;
                            if (rotationOffset > 360) {
                                rotationOffset -= 360;
                            }
                        }
                        
                    }
                }
            }
            if (this.type == "Roller") { }// Do Nothing
        }
    }
}
