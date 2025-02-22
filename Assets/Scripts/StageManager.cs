using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public int StageNum = 1; // ±âº»°ª 1
    public Text Stage;

    public void StageInfo()
    {
        Stage.text = "Stage " + StageNum;
    }
}
