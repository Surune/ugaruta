using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCS : MonoBehaviour
{
    public GameObject Monster;
    public string PlayerName; // �÷��̾� ĳ������ �̸�

    public int Current_HP; // �÷��̾� ĳ������ ���� ü��
    public int HP; // �÷��̾� ĳ������ ü�� (��) 

    public int Attack; // ���ݷ�

    public Text _Name; // ȭ��� ��Ÿ���� ĳ���� �̸� 
    public Text _HP; // ȭ��� ��Ÿ���� ĳ������ ü��

    public Animator Anim;

    private void Start()
    {
        _Name.text = PlayerName;
        _HP.text = Current_HP + " / " + HP; // ���� ü�� + " / " + �� ü��

        Monster = GameObject.FindGameObjectWithTag("monster");
    }

    private void Update()
    {

        if (Monster != null)
        {
            if (Monster.GetComponent<MonsterCS>().Current_HP > 0) // ���Ͱ� ���� �ʾ��� ��,
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
