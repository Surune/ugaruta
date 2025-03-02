using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowCanvas;
    public Transform spawnPoint;
    public Transform targetPoint;
    public float arrowSpeed = 5f;
    public List<ArrowData> arrowDatas = new List<ArrowData>();

    private List<Arrow> arrows = new List<Arrow>();
    private List<KeyCode> arrowKeys;
    void Start()
    {
        StartCoroutine(SpawnArrows());
        arrowKeys = arrowDatas.Select(x => x.KeyCode).ToList();
    }

    void Update()
    {
        MoveArrows();
        CheckInput();
    }

    IEnumerator SpawnArrows()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2.5f));
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        Arrow newArrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity, arrowCanvas).GetComponent<Arrow>();
        newArrow.SetData(arrowDatas[Random.Range(0, arrowDatas.Count)]);
        arrows.Add(newArrow);
    }

    void MoveArrows()
    {
        for (int i = 0; i < arrows.Count; i++)
        {
            if (arrows[i] != null)
            {
                arrows[i].transform.position = Vector3.MoveTowards(arrows[i].transform.position, targetPoint.position, arrowSpeed * Time.deltaTime);
            }
        }
    }

    void CheckInput()
    {
        foreach (var key in arrowKeys)
        {
            if (Input.GetKeyDown(key))
            {
                CheckHit(key);
            }
        }
    }

    void CheckHit(KeyCode key)
    {
        for (var i = 0; i < arrows.Count; i++)
        {
            if (arrows[i].myData.KeyCode == key)
            {
                float distance = Vector3.Distance(arrows[i].transform.position, targetPoint.position);
                if (distance < 0.5f)
                {
                    Destroy(arrows[i].gameObject);
                    arrows.RemoveAt(i);
                    Debug.Log("Perfect Hit!");
                    break;
                }
            }
        }
    }
}

[Serializable]
public struct ArrowData
{
    public KeyCode KeyCode;
    public string Text;
    public Color Color;
}
