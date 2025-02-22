using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    private GameObject player;
    public GameObject knockbackobject;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerSprite");

        if (player.transform.localScale[0] > 0)
        {
            rb.velocity = new Vector2(30f, 0);
            transform.localScale = new Vector3(-3f, 3f, 1f);
        }
        else if (player.transform.localScale[0] < 0)
        {
            rb.velocity = new Vector2(-30f, 0);
            transform.localScale = new Vector3(3f, 3f, 1f);
        }
    }
    
    // Update is called once per frame
    void Update () {
        if (transform.position[1] < -50 || transform.position[1] > 50 || transform.position[0] < -20 || transform.position[0] > 20) Destroy(gameObject);

    }
}
