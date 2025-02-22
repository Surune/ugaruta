using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject character; // ĳ���� ������Ʈ.
    public RectTransform touchArea; // Joystick Touch Area �̹����� RectTransform.
    public Image outerPad; // OuterPad �̹���.
    public Image innerPad; // InnerPad �̹���.
    public bool lookRight; // true=������, false=����

    private Vector2 joystickVector; // ���̽�ƽ�� ���⺤������ �÷��̾�� �ѱ� ��������.

    private float myspeed = 1f; // ĳ���� ���ǵ�
    private float rotateSpeed = 5f; // ȸ�� �ӵ�

    private Coroutine runningCoroutine; // �ε巯�� ȸ�� �ڷ�ƾ

    void Start()
    {
        lookRight = true;
        joystickVector = new Vector2(0.35f, 0);
        //runningCoroutine = StartCoroutine(RotateAngle(180, -1));
        // �����ϸ� charactor�� 180�� ���������� ȸ��
    }


    void Update()
    {
        myspeed = character.GetComponent<Player>().speed;
        character.GetComponent<Rigidbody2D>().velocity = joystickVector * 8 * myspeed; // character.transform.up * speed;
        // ĳ���ʹ� 3�� �ӵ��� ��� ����
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(touchArea,
            eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            localPoint.x = (localPoint.x / touchArea.sizeDelta.x);
            localPoint.y = (localPoint.y / touchArea.sizeDelta.y);
            // Joystick Touch Area�� ���� ���ϱ� ( -0.5 ~ 0.5 )

            joystickVector = new Vector2(localPoint.x * 2.6f, localPoint.y * 2);
            // ���̽�ƽ ���� ���� (2.6�� 2�� ������ ���� TouchArea�� ���� ������)

            joystickVector.Normalize();
            lookRight = joystickVector.x >= 0 ? true : false;
            //TurnAngle(trail, joystickVector);
            // Character���� ���̽�ƽ ���� �ѱ��

            joystickVector = (joystickVector.magnitude > 0.35f) ? joystickVector.normalized * 0.35f : joystickVector;
            // innerPad �̹����� outerPad�� �Ѿ�ٸ� ��ġ �������ֱ�

            innerPad.rectTransform.anchoredPosition = new Vector2(joystickVector.x * (outerPad.rectTransform.sizeDelta.x),
                joystickVector.y * (outerPad.rectTransform.sizeDelta.y));
            // innerPad �̹��� ��ġ�� ������ �ű��
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData); // ��ġ�� ���۵Ǹ� OnDrag ó��.
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        innerPad.rectTransform.anchoredPosition = Vector2.zero;
    }


    private void TurnAngle(GameObject obj, Vector3 currentJoystickVec)
    {
        Vector3 originJoystickVec = obj.transform.up;
        // character�� �ٶ󺸰� �ִ� ����

        float angle = Vector3.Angle(currentJoystickVec, originJoystickVec);
        int sign = (Vector3.Cross(currentJoystickVec, originJoystickVec).z > 0) ? -1 : 1;
        // angle: ���� �ٶ󺸰� �ִ� ���Ϳ�, ���̽�ƽ ���� ���� ������ ����
        // sign: character�� �ٶ󺸴� ���� ��������, ����:+ ������:-

        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
        }
        runningCoroutine = StartCoroutine(RotateAngle(obj, angle, sign));
        // �ڷ�ƾ�� �������̸� ���� ���� �ڷ�ƾ �ߴ� �� �ڷ�ƾ ���� 
        // �ڷ�ƾ�� �� ���� �����ϵ���.
        // => ȸ�� �߿� ���ο� ȸ���� ������ ���, ȸ�� ���̴� ���� ���߰� ���ο� ȸ���� ��.
    }


    IEnumerator RotateAngle(GameObject obj, float angle, int sign)
    {
        float mod = angle % rotateSpeed; // ���� ���� ���
        for (float i = mod; i < angle; i += rotateSpeed)
        {
            obj.transform.Rotate(0, 0, sign * rotateSpeed); // ĳ���� rotateSpeed��ŭ ȸ��
            yield return new WaitForSeconds(0.01f); // 0.01�� ���
        }
        obj.transform.Rotate(0, 0, sign * mod); // ���� ���� ȸ��
    }
}
