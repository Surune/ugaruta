using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCS : MonoBehaviour
{
    public GameObject Monster;
    public string PlayerName; // 플레이어 캐릭터의 이름

    public int Current_HP; // 플레이어 캐릭터의 현재 체력
    public int HP; // 플레이어 캐릭터의 체력 (총) 

    public int Attack; // 공격력

    public Text _Name; // 화면상에 나타나는 캐릭터 이름 
    public Text _HP; // 화면상에 나타나는 캐릭터의 체력

    public Animator Anim;

    private void Start()
    {
        _Name.text = PlayerName;
        _HP.text = Current_HP + " / " + HP; // 현재 체력 + " / " + 총 체력

        Monster = GameObject.FindGameObjectWithTag("monster");
    }

    private void Update()
    {

        if (Monster != null)
        {
            if (Monster.GetComponent<MonsterCS>().Current_HP > 0) // 몬스터가 죽지 않았을 때,
            {
                Anim.SetInteger("AnimState", 1);
            }
        }
        else if (Monster == null)
        {
            Anim.SetInteger("AnimState", 2);
        }
    }

    public void AttackMonster()
    {
        Monster.GetComponent<MonsterCS>().Current_HP -= Attack; 
    }
}
