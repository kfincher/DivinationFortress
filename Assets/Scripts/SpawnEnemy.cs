using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// aka the wave controls
public class SpawnEnemy : MonoBehaviour
{
    public int index = 0;
    public bool Auto;
    private float spawnBuffer = 3f;
    private float nextSpawn;
    
    private int waveNum = 1;

    [HideInInspector]
    public int remainingEnemies = 0;
    public GameObject nextWaveText;
    public Text text;
    public GameObject[] Enemy;
    public GameObject upgradeUIElements;
    public GameObject PointsUI;
    public GameObject player;
    public Stack <int> wave = new Stack<int>();


    private int currWaveGroup = 1;
    //private int[,] waveStack = {{0},
    //                            {1,0,0,0},
    //                            {1,0,0,0},
    //                            {1,0,0,0},
    //                            {1,0,0,0 }};


   string [] waveList = { "0","01","12","223","0123"  };

    //private int[][] waveAll = new int[5][10];
    // Start is called before the first frame update

    void Start()
    {      
        for(int i = 0; i < waveList[0].Length;i++){
            int temp = waveList[0][i]-'0';
            wave.Push(temp);
        }
        nextWaveText.SetActive(false);
        upgradeUIElements.SetActive(false);
        text.text = "Wave: " + waveNum ;
        remainingEnemies = waveList[0].Length;
        Auto = true;
        nextSpawn = Time.time+1f;
    }

    // Update is called once per frame
    void Update(){
        // Spawns each wave
        if (Auto&&nextSpawn<Time.time&&wave.Count>0&&remainingEnemies>0) {
            nextSpawn = Time.time + spawnBuffer; // controls duration between each spawn
            index = wave.Pop();
            GameObject temp = Instantiate(Enemy[index], transform.position, transform.rotation);
            index++;
            if (index > 3)
                index = 0;
            temp.GetComponent<EnemyPathfinding>().moveNow();
            
           
        } 
        if(remainingEnemies==0){
            player.GetComponent<PlayerUpgradeSystem>().upgradePoints+=2;
            PointsUI.GetComponent<Text>().text = "Points: " + player.GetComponent<PlayerUpgradeSystem>().upgradePoints + "p";
            nextWaveText.SetActive(true);
            upgradeUIElements.SetActive(true);
            player.GetComponent<PlayerMovement>().cursorOn();
            player.GetComponent<PlayerUpgradeSystem>().open = true;
            remainingEnemies = -1;
        }
        if (remainingEnemies <= 0) {
            PointsUI.GetComponent<Text>().text = "Points: " + player.GetComponent<PlayerUpgradeSystem>().upgradePoints + "p";
        }
        if (remainingEnemies <= 0&& Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("Next wave incoming!");
            nextWaveText.SetActive(false);
            upgradeUIElements.SetActive(false);
            player.GetComponent<PlayerMovement>().cursorOff();
            player.GetComponent<PlayerUpgradeSystem>().open = false;
            waveNum++;
            text.text = "Wave: " + waveNum;
            for (int i = 0; i < waveList[currWaveGroup].Length; i++) {
                int temp = waveList[currWaveGroup][i] - '0';
                wave.Push(temp);
            }
            remainingEnemies = waveList[currWaveGroup].Length;
            currWaveGroup++;
            if (currWaveGroup>4) {
                currWaveGroup = 0;
            }

        }



        // Debug controls
        if (Input.GetKeyDown(KeyCode.O)) { // Standard Enemy
            GameObject temp = Instantiate(Enemy[0], transform.position, transform.rotation);
            temp.GetComponent<EnemyPathfinding>().moveNow();
        }
        if (Input.GetKeyDown(KeyCode.P)) { // Fighter Enemy
            GameObject temp = Instantiate(Enemy[1], transform.position, transform.rotation);
            temp.GetComponent<EnemyPathfinding>().moveNow();
        }
        if (Input.GetKeyDown(KeyCode.I)) { // AoE Enemy
            GameObject temp = Instantiate(Enemy[2], transform.position, transform.rotation);
            temp.GetComponent<EnemyPathfinding>().moveNow();
        }
        if (Input.GetKeyDown(KeyCode.U)) { // Roller Enemy
            GameObject temp = Instantiate(Enemy[3], transform.position, transform.rotation);
            temp.GetComponent<EnemyPathfinding>().moveNow();
        }
    }
}