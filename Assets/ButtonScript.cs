using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button boop;
    public Button play;
    public Button credits;
    public Button back;
    public GameObject Main;
    public GameObject Credit;
    bool swapper = true;
    // Start is called before the first frame update
    void Start()
    {
        boop.onClick.AddListener(doExitGame);
        play.onClick.AddListener(playGame);
        credits.onClick.AddListener(swap);
        back.onClick.AddListener(swap);
    }

    void swap()
    {
        swapper = !swapper;
        Main.SetActive(swapper);
        Credit.SetActive(!swapper);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void playGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void doExitGame()
    {
        Application.Quit();
    }
}
