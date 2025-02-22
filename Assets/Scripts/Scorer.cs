using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scorer : MonoBehaviour
{
    public float time;
    private int[] score = new int[4];
    public GameObject Choice;
    //static bool selecting;
    TextMeshProUGUI resourceText;
    public AudioSource musicPlayer;
    public AudioClip sfx_killed;
    public AudioClip sfx_bonus;
    public TextMeshProUGUI[] combo;
    public int deck;

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = gameObject.GetComponent<AudioSource>();
        resourceText = GetComponent<TextMeshProUGUI>();
        time = 0;
        score[0] = 0;
        score[1] = 0;
        score[2] = 0;
        score[3] = 0;
        deck = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        resourceText.text = " cur deck: " + (Mathf.Round(time)+score[0]+score[1]+score[2]+score[3] + " / now deck: "+deck);
        //resourceText.text += "\n"+score[0]+"/"+score[1]+"/"+score[2]+"/"+score[3];
        for (int i = 0; i < 4; i++)
        {
            if (score[i] >= 10)
            {
                Instantiate(Choice, new Vector3(0f, 0f, 0f), Quaternion.identity);
                Time.timeScale = 0;
                musicPlayer.PlayOneShot(sfx_bonus);
                score[i] -= 10;
                deck += 1;
            }
            combo[i].text = "" + score[i];
        }
    }

    public void ScoreChange(int type, int num)
    {
        score[type-1] += num;
        musicPlayer.PlayOneShot(sfx_killed);
    }
}
