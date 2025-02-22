using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCS : MonoBehaviour
{
    public GameObject Player;
    public string MonsterName; // ���� �̸�

    public int Current_HP; // ������ ���� ü��
    public int HP; // ������ �� ü��

    public int Attack; // ������ ���ݷ� 

    public Text _Name;
    public Text _HP; // ȭ��� ��Ÿ���� ������ ü��
    public StageManager stage;

    public Animator Anim;

    private void Start()
    {
        _Name.text = MonsterName;
        Player = GameObject.FindGameObjectWithTag("player");
    }

    private void Update()
    {
        _HP.text = Current_HP + " / " + HP; // ���� ü�� + " / " + �� ü��

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
        this.gameObject.SetActive(false); // �ش� ������Ʈ ��Ȱ��ȭ
        Invoke("Regen", 2); // ������Ʈ 2�� �Ŀ� ��Ȱ
    }

    public void Regen() // ���� ��Ȱ
    {
        Current_HP = HP;
        _Name.gameObject.SetActive(true);
        _HP.gameObject.SetActive(true);
        this.gameObject.SetActive(true);
        Player.GetComponent<PlayerCS>().Monster = this.gameObject;
    }
}
