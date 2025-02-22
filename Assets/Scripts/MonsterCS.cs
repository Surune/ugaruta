using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCS : MonoBehaviour
{
    public GameObject Player;
    public string MonsterName; // 몬스터 이름

    public int Current_HP; // 몬스터의 현재 체력
    public int HP; // 몬스터의 총 체력

    public int Attack; // 몬스터의 공격력 

    public Text _Name;
    public Text _HP; // 화면상에 나타나는 몬스터의 체력
    public StageManager stage;

    public Animator Anim;

    private void Start()
    {
        _Name.text = MonsterName;
        Player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP; // 현재 체력 + " / " + 총 체력

        if (Current_HP <= 0)
        {
            Anim.SetInteger("AnimState", 1);
            Player.GetComponent<PlayerCS>().Monster = null;
        }
    }

    public void Death()
    {
        _Name.gameObject.SetActive(false);
        _HP.gameObject.SetActive(false);
        stage.StageNum++;
        stage.StageInfo();
    }

    public void Off_obj()
    {
        this.gameObject.SetActive(false); // 해당 오브젝트 비활성화
        Invoke("Regen", 2); // 오브젝트 2초 후에 부활
    }

    public void Regen() // 몬스터 부활
    {
        Current_HP = HP;
        _Name.gameObject.SetActive(true);
        _HP.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        Player.GetComponent<PlayerCS>().Monster = this.gameObject;
    }
}
