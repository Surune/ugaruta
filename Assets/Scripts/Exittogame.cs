using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Exittogame : MonoBehaviour
{
    public Button togame;
    public TextMeshProUGUI scoretext;
    private int nowdeck;
    private int totaldeck;

    // Start is called before the first frame update
    void Start()
    {
        togame.GetComponent<Button>().onClick.AddListener(exittogame);
        nowdeck = PlayerPrefs.GetInt("nowdeck");
        totaldeck = PlayerPrefs.GetInt("totaldeck")+nowdeck;
        scoretext.text="È¹µæÇÑ µ¦ ¼ö:" + nowdeck + "\n\nÃÑ µ¦ ¼ö:" + totaldeck;
        PlayerPrefs.SetInt("totaldeck", totaldeck);
        PlayerPrefs.SetInt("nowdeck", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void exittogame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("maingame");
    }
}
