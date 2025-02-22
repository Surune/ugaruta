using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {
    public float delay;

    // Use this for initialization
    void Start () {
        Invoke("Destroy", delay);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
    
    public void SetEffectColor(int type)
    {
        var main = GetComponent<ParticleSystem>().main;

        if (type == 1) main.startColor = new Color(0, 104f/255f, 1, 1);
        else if (type == 2) main.startColor = new Color(1, 0, 0, 1);
        else if (type == 3) main.startColor = new Color(0, 156f/255f, 25f/255f, 1);
        else if (type == 4) main.startColor = new Color(1, 196f/255f, 0, 1);
    }
}
