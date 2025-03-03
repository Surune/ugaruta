using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
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
    public TMP_Text notification;

    private List<Arrow> arrows = new List<Arrow>();
    private List<KeyCode> arrowKeys;
    void Start()
    {
        StartCoroutine(SpawnArrows());
        arrowKeys = arrowDatas.Select(x => x.KeyCode).ToList();
    }

    void Update()
    {
        CheckInput();
    }

    IEnumerator SpawnArrows()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.25f, 1f));
            SpawnArrow();
        }
    }

    void SpawnArrow()
    {
        Arrow newArrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity, arrowCanvas).GetComponent<Arrow>();
        newArrow.SetData(arrowDatas[Random.Range(0, arrowDatas.Count)]);
        newArrow.MoveDirection = (targetPoint.position - spawnPoint.position).normalized;
        arrows.Add(newArrow);
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
        var firstArrow = arrows.First();
        if (firstArrow.myData.KeyCode == key)
        {
            float distance = Vector3.Distance(firstArrow.transform.position, targetPoint.position);
            var notificationText = "miss";
            if (distance < 0.25f)
            {
                notificationText = "perfect";
            }
            else if (distance < 0.5f)
            {
                notificationText = "great";
            }
            else if (distance < 0.75f)
            {
                notificationText = "good";
            }
            Destroy(firstArrow.gameObject);
            arrows.Remove(firstArrow);
            notification.text = notificationText;
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
