using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using static Triangulator;

public class Player : MonoBehaviour {
    //float directionx;
    //float directiony;
    //Rigidbody2D rb;
    //public GameObject GameOver;
    //public GameObject choice;
    private JoystickController joystick;
    private EnemySpawn EnemySpawner;
    private Animator playerAnimation;
    public TrailRendererWith2DCollider trailer;
    public int trail_type;
    private PlayerHealth HP;
    private bool limited;
    private SpriteRenderer barrier_sprite;
    public float size = 2f;
    public bool Respawning;
    private float respawncool = 1.5f;
    private float respawntime = 0f;
    public float skillcool_max = 20f;
    private float skillcool_now = 0;
    public float speed = 1f;
    public GameObject barrier;
    public GameObject btn;
    [SerializeField]
    private Image img_Skill;
    [SerializeField]
    private TextMeshProUGUI text_Skill;

    // Use this for initialization
    void Start () {
        // rb = GetComponent<Rigidbody2D>();
        HP = GameObject.Find("Slider").GetComponent<PlayerHealth>();
        EnemySpawner = GameObject.Find("Spawner").GetComponent<EnemySpawn>();
        joystick = GameObject.Find("Joystick").GetComponent<JoystickController>();
        // GameOver.SetActive(false);
        //transform.localScale = new Vector2(size, size);
        playerAnimation = GetComponent<Animator>();
        trailer = GetComponent<TrailRendererWith2DCollider>();
        // barrier_sprite = GameObject.Find("barrier").GetComponent<SpriteRenderer>();
        // img_Skill = btn.GetComponent<Image>();
        // text_Skill = btn.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public GameObject pl;
    private Coroutine runningCoroutine;
    public bool rolling = false;

    public void Roll()
    {
        Instantiate(barrier, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        //if (!rolling) runningCoroutine = StartCoroutine(Rotate(3)); // RotateAngle(pl, 360, 1));
        if (runningCoroutine != null) {
            StopCoroutine(runningCoroutine);
        }
        btn.GetComponent<Button>().interactable = false;
        rolling = true;
        //runningCoroutine = StartCoroutine(Rotate(0.6f));
        //StartCoroutine(CoolTime(0.6f));
        skillcool_now = skillcool_max;
        Invoke("RollingOff", 0.75f);
    }

    IEnumerator CoolTime(float cool)
    {
        var img_Skill = btn.GetComponent<Image>();
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            img_Skill.fillAmount = (1.0f / cool);
            yield return new WaitForFixedUpdate();
        }
        rolling = false;
    }

    private void RollingOff()
    {
        rolling = false;
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.z;//y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, yRotation);//,            transform.eulerAngles.z);
            yield return null;
        }
        rolling = false;
    }

    // Update is called once per frame
    void Update () {
        if (skillcool_now - Time.deltaTime > 0)
        {
            skillcool_now -= Time.deltaTime;
            img_Skill.fillAmount = 1 - skillcool_now / skillcool_max;
            text_Skill.text = Mathf.Round(skillcool_now) + "s";
        }
        else
        {
            btn.GetComponent<Button>().interactable = true;
            img_Skill.fillAmount = 1;
            rolling = false;
            text_Skill.text = "";
        }

        //if (joystick.lookRight) transform.localScale = new Vector2(size, size);
        //else transform.localScale = new Vector2(-size, size);

        if (Respawning)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
            respawntime += Time.deltaTime;
            if (respawntime > respawncool)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
                respawntime = 0f;
                Respawning = false;
            }
        }

        limited = false;
        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) 
        {
            worldpos.x = 0f;
            limited = true;
        }
        if (worldpos.y < 0f)
        {
            worldpos.y = 0f;
            limited = true;
        }
        if (worldpos.x > 1f)
        {
            worldpos.x = 1f;
            limited = true;
        }
        if (worldpos.y > 1f)
        {
            worldpos.y = 1f;
            limited = true;
        }
        if(limited)  this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

        //playerAnimation.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        //playerAnimation.SetFloat("JumpSpeed",(rb.velocity.y));
        //playerAnimation.SetBool("GroundCheck", isTouchingGround);
    }
}