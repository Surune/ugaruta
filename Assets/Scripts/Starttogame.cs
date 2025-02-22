using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starttogame : MonoBehaviour
{
    public Button togame;
    //public Image sprite;
    //float time;
    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponent<Image>();
        togame.GetComponent<Button>().onClick.AddListener(starttogame);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (time<1f)
        {
            sprite.color = new Color(1, 1, 1, 1 - time/2);
        }
        else
        {
            sprite.color = new Color(1, 1, 1, time/2);
            if (time > 2f)  time = 0;
        }
        */
        //time += Time.deltaTime;
    }

    void starttogame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("maingame");
    }
}
