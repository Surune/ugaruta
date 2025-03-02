using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public ArrowData myData;
    public Image image;
    public TMP_Text arrowText;

    public void SetData(ArrowData data)
    {
        myData = data;
        image.color = data.Color;
        arrowText.text = data.Text;
    }
}
