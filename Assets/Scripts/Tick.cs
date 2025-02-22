using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tick : MonoBehaviour {
    public bool onTrigger;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Arc")) {
            onTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        onTrigger = false;
    }
}
