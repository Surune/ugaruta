using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour
{
    public float delay;
    private GameObject player;
    private TrailRendererWith2DCollider trailer;
    private SpriteRenderer myRenderer;
    int ran;
    private float time;
    [SerializeField]
    public Sprite[] ink_sprites;
    [SerializeField]
    public Material[] materials;
    public AudioSource musicPlayer;
    public AudioClip sfx_ink;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", delay);
        player = GameObject.Find("Player");
        musicPlayer = GameObject.Find("Scorer").GetComponent<AudioSource>();
        trailer = player.GetComponent<TrailRendererWith2DCollider>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        ran = Random.Range(0, ink_sprites.Length);
        myRenderer.sprite = ink_sprites[ran];
        time = 0;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            trailer.ChangeTrailMaterial(materials[ran]);
            player.GetComponent<Player>().trail_type = ran+1;
            musicPlayer.PlayOneShot(sfx_ink);
            Destroy(gameObject);
        }
    }
        
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        myRenderer.color = new Color(1, 1, 1, 1-(time/delay)* (time / delay));
    }
}