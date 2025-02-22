using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    public bool enableSpawn = true;
    public GameObject[] Butterflies;
    public GameObject Ink;
    private GameObject canvas;

    public GameObject EnemyList;
    public GameObject InkList;

    float max_x, max_y;
    // Use this for initialization
    void Start()
    {
        enableSpawn = true;
        InvokeRepeating("SpawnEnemy", 0, 1.5f); //3초후 부터, SpawnEnemy함수를 1초마다 반복해서 실행 시킵니다.
        //InvokeRepeating("SpawnInk", 0, 2.5f);
        canvas = GameObject.Find("Canvas");
        max_x = canvas.GetComponent<RectTransform>().rect.width/2;
        max_y = canvas.GetComponent<RectTransform>().rect.height/2;
    }

    // Update is called once per frame
    private void SpawnEnemy()
    {
        float randomX = Random.Range(-max_x * 0.9f, max_x * 0.9f); // 좌표를 랜덤으로 생성해 줍니다.
        float randomY = Random.Range(-max_y * 0.9f, max_y * 0.9f);

        int ran = Random.Range(0, 5);
        GameObject enemy;
        if (Time.timeScale!= 0 && enableSpawn)
        {
            //GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, 1.1f, 0f), Quaternion.identity); //랜덤한 위치와, 화면 제일 위에서 Enemy를 하나 생성해줍니다.
            enemy = Instantiate(Butterflies[ran%4], EnemyList.transform);
            //enemy.transform.position = new Vector3(randomX, randomY, 0f);
        }
    }

    private void SpawnInk()
    {
        float randomX = Random.Range(-max_x*0.95f, max_x*0.95f); // 좌표를 랜덤으로 생성해 줍니다.
        float randomY = Random.Range(-max_y*0.95f, max_y*0.95f);
        GameObject ink = Instantiate(Ink, new Vector3(randomX, randomY, 0f), Quaternion.identity);
        ink.transform.SetParent(InkList.transform);
    }

    public void Gameover()
    {
        enableSpawn = false;
    }
}