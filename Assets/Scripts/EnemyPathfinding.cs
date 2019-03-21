using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPathfinding : MonoBehaviour
{
    public Image HealthBar;
    public string EnemyType;
    public GameObject Player;
    public GameObject EndPoint;
    public GameObject spawner;
    public GameObject[] Enemy;
    public GameObject EndText;

    public GameObject rollerMesh;

    public Text text;

    private float timeTaken;

    public float speed = 5;
    private bool turned = false;
    [HideInInspector]
    public bool move = false;

    private float spawnTime;
    private bool spawnBool;
    private float maxhealth = 100f;
    private float health;
    public void moveNow()
    {
        move = true;
        this.spawnTime = Time.time+0.5f;
    }


    // Start is called before the first frame update
    void Start()
    {
        this.spawnBool = false;
        health = maxhealth;
        timeTaken = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") { 
            for (int i = 0; i < Enemy.Length; i++) {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") {
            float counter = 1f;
            if (EnemyType == "Roller") {
                counter = 0.5f;
            }
            this.health -= Player.GetComponent<PlayerShooting>().damage*counter;
            text.GetComponent<HealthTextUpdate>().updateHealth(health,maxhealth);

            Vector2 temp = HealthBar.rectTransform.sizeDelta;
            temp.x = 5 * (health/maxhealth);
            HealthBar.rectTransform.sizeDelta = temp;
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
        
        if (other.tag == "End") {
            Destroy(gameObject);
            EndText.GetComponent<EnderHealthUpdate>().healthUpdate();
        }

        if (other.tag == "Player"&&EnemyType == "Roller") {
            Debug.Log("Player was hit!");
        }

    }
    private void OnDestroy()
    {
        spawner.GetComponent<SpawnEnemy>().remainingEnemies--;
    }
    // Update is called once per frame
    void Update()
    {
        if (move == true) {
            if (EnemyType == "Roller") {
                rollerMesh.transform.Rotate(3, 0, 0);
                transform.LookAt(Player.transform);
            }
            if(this.spawnBool == false && this.spawnTime < Time.time) {
                this.spawnBool = true;
                gameObject.GetComponent<EnemyShooting>().activate();
            }
            gameObject.GetComponent<Rigidbody>().position += transform.forward * Time.deltaTime * speed;
            if (this.turned==false&&transform.position.z <= EndPoint.transform.position.z) {
                transform.Rotate(0,90,0);
                this.turned = true;
            }
        }
    }
}
