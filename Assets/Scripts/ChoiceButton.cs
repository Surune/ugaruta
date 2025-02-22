using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour {
    // Use this for initialization

    public GameObject choice;
    private Button thisbutton;
    public int btnnum;
    private PlayerHealth HP;
    private Player player;

    void Start () 
    {
        HP = GameObject.Find("Slider").GetComponent<PlayerHealth>();
        player = GameObject.Find("Player").GetComponent<Player>();
        thisbutton = GetComponent<Button>();
        //thisbutton.onClick.AddListener(Selected);
        if (btnnum == 1)        thisbutton.onClick.AddListener(Spade);
        else if (btnnum==2)     thisbutton.onClick.AddListener(Heart);
        else if (btnnum == 3)   thisbutton.onClick.AddListener(Clover);
        else if (btnnum == 4)   thisbutton.onClick.AddListener(Diamond);
    }

    private void Spade()
    {
        player.trailer.lifeTime += 0.2f;
        Selected();
    }

    private void Heart()
    {
        HP.ChangeHP(+20);
        Selected();
    }

    private void Clover()
    {
        player.skillcool_max *= 0.9f;
        Selected();
    }

    private void Diamond()
    {
        player.speed *= 1.05f;
        Selected();
    }

    public void Selected()
    {
        player.Respawning = true;
        Time.timeScale = 1;
        Destroy(choice);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
