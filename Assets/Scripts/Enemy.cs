using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int type;
    public GameObject deatheffect;
    private SpriteRenderer myRenderer;
    private GameObject scorer;
    private PlayerHealth HP;

    // Use this for initialization
    void Start () {
        HP = GameObject.Find("Slider").GetComponent<PlayerHealth>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        scorer = GameObject.Find("Scorer");
        center = GameObject.Find("Enemy").transform;

        orbitRadius = Vector3.Distance(transform.position, center.position);

        // 시작 위치에 따른 시작 각도 계산
        Vector3 directionToCenter = center.position - transform.position;
        startingAngle = Mathf.Atan2(-directionToCenter.y, directionToCenter.x) * Mathf.Rad2Deg;
        endTime = Time.time;

    }

    private Transform center; // 중심점 (예: 태양)
    public float orbitSpeed = 1f; // 공전 속도

    private float orbitRadius; // 몬스터와 중심 사이의 거리
    private float startingAngle; // 시작 각도

    public float penetrationSpeed = 100f; // 관통 속도

    private bool isPenetrating; // 관통 여부를 나타내는 플래그
    private Vector3 initialPosition; // 초기 위치
    private float startTime; // 시작 시간
    private float endTime;

    // Update is called once per frame
    void FixedUpdate () {
        if (isPenetrating) {
            float distanceCovered = (Time.time - startTime) * penetrationSpeed;
            float journeyLength = orbitRadius;
            float fractionOfJourney = distanceCovered / journeyLength;

            // 칼이 한쪽 원에서 구의 중심을 관통하여 반대쪽으로 이동
            Vector3 direction = (center.position - initialPosition).normalized;
            Vector3 targetPosition = initialPosition + direction * journeyLength;

            if (fractionOfJourney < 1f) {
                transform.position = Vector3.Lerp(initialPosition, targetPosition, fractionOfJourney);
            }
            else {
                transform.position = targetPosition;
                isPenetrating = false;
                // 시작 위치에 따른 시작 각도 계산
                Vector3 directionToCenter = center.position - transform.position;
                startingAngle = Mathf.Atan2(directionToCenter.y, -directionToCenter.x) * Mathf.Rad2Deg;
                endTime = Time.time;
                Debug.Log("PENETRATE END");
            }
        }
    }

    public void TogglePenetration() {
        isPenetrating = !isPenetrating;

        if (isPenetrating) {
            startTime = Time.time;
            initialPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(deatheffect, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
