using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnderHealthUpdate : MonoBehaviour
{
    int health = 20;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }
    public void healthUpdate()
    {
        health--;
        text.text = health + "/20";
        if (health <= 0) {
            SceneManager.LoadScene("TitleScreen");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
