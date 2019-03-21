using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScaler : MonoBehaviour
{
    RectTransform rect;
    private float x;
    private float y;
    private Vector2 res;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        res = new Vector2(Screen.width, Screen.height);
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width/5, Screen.height/18);

        text.rectTransform.localScale = new Vector2(rect.sizeDelta.x / 200, rect.sizeDelta.y / 40);
        x = Screen.width/-2;
        //x = Screen.width / -1.7f;
        //y = Screen.height / 1.7f;
        y = (Screen.height / 2) - rect.sizeDelta.y;
        rect.anchoredPosition = new Vector2(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (res.x != Screen.width || res.y != Screen.height) {
            rect.sizeDelta = new Vector2(Screen.width / 6, Screen.height / 20);

            text.rectTransform.localScale = new Vector2(rect.sizeDelta.x/200,rect.sizeDelta.y/40);
            x = Screen.width / -2;
            y = (Screen.height / 2)-rect.sizeDelta.y;
            //y = 206f;
            rect.anchoredPosition = new Vector2(x, y);
            res.x = Screen.width;
            res.y = Screen.height;
        }
    }
}
