using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    [SerializeField]
    public float speed;

    void Start()
    {
        //StartCoroutine(CoolTime(3f));
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 1f) * Time.deltaTime *speed);
    }
}