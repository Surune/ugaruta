using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Circle : MonoBehaviour {
    public Transform tick;
    public GameObject arc_prefab;
    public GameObject fireball;
    [SerializeField]
    private GameObject current_fireball;
    public Tick ticking;
    public float rotationSpeed = 480f;
    public AudioSource musicPlayer;
    public AudioClip sfx_ink;

    private void Update() {
        float angle = Time.deltaTime * rotationSpeed; // 초당 회전 각도 계산
        tick.Rotate(0f, 0f, -angle);
    }
    
    private WaitForSeconds spawnInterval;

    private void Start() {
        spawnInterval = new WaitForSeconds(1f);
        StartCoroutine(SpawnArcs());
    }

    private GameObject current_arc;

    private IEnumerator SpawnArcs() {
        while (true) {
            float randomRotationAngle = Random.Range(0f, 210f);

            // arcPrefab을 spawnPoint 위치에 Instantiate
            if(current_arc != null)
                Destroy(current_arc);
            current_arc = Instantiate(arc_prefab, this.transform);
            current_arc.transform.rotation = Quaternion.Euler(0f, 0f, randomRotationAngle);

            // 1초 대기
            yield return spawnInterval;
        }
    }

    public void JungClicked() {
        // TODO : check timing
        if(ticking.onTrigger) {
            Debug.Log("JUNG");
            current_fireball = Instantiate(fireball, this.transform);
            current_fireball.GetComponent<SpriteRenderer>().color = Color.white;
            current_fireball.GetComponent<Enemy>().TogglePenetration();
            musicPlayer.PlayOneShot(sfx_ink);
        }
    }

    public void BanClicked() {
        // TODO : check timing
        if(ticking.onTrigger) {
            Debug.Log("BAN");
            current_fireball = Instantiate(fireball, this.transform);
            current_fireball.GetComponent<SpriteRenderer>().color = Color.black;
            current_fireball.GetComponent<Enemy>().TogglePenetration();
            musicPlayer.PlayOneShot(sfx_ink);
        }
    }
}