using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour 
{
    private Slider healthbar;
    private int currentHP;
    private int maxHP;
    public AudioSource musicPlayer;
    public AudioClip sfx_hit;
    public TextMeshProUGUI hp_text;

    // Use this for initialization
    void Start () 
    {
        healthbar = GetComponent<Slider>();
        maxHP = 100;
        currentHP = maxHP;
        healthbar.value = currentHP;
        //musicPlayer = GameObject.Find("Player").GetComponent<AudioSource>();
        PlayerPrefs.SetFloat("nowdeck", 0f);
    }

    // Update is called once per frame
    public void ChangeHP(int d)
    {
        currentHP += d;
        if (currentHP >= maxHP) currentHP = maxHP;
        if (d < 0) musicPlayer.PlayOneShot(sfx_hit);
    }

    public int ReturnHP()
    {
        return currentHP;
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            PlayerPrefs.SetInt("nowdeck", GameObject.Find("Scorer").GetComponent<Scorer>().deck);
            UnityEngine.SceneManagement.SceneManager.LoadScene("gameover");
        }

        healthbar.value = currentHP;
        hp_text.text = currentHP + " / " + maxHP;
    }
}
