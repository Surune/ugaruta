using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    int exitCountValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void disable_DoubleClick()
    {
        exitCountValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            exitCountValue++;
            if (!IsInvoking("disable_DoubleClick"))
                Invoke("disable_DoubleClick", 0.2f);
        }
        if (exitCountValue == 2)
        {
            CancelInvoke("disable_DoubleClick");
            Application.Quit();
        }
    }
}
