using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 5f;
    public Vector3 MoveDirection;
    public ArrowData myData;
    public Image image;
    public TMP_Text arrowText;

    void Update()
    {
        transform.position += MoveDirection * (arrowSpeed * Time.deltaTime);
    }

    public void SetData(ArrowData data)
    {
        myData = data;
        image.color = data.Color;
        arrowText.text = data.Text;
    }
}
