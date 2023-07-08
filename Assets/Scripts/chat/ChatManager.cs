using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class ChatManager : MonoBehaviour
{
    public GameObject YellowArea, WhiteArea, DateArea;
    public RectTransform ContentRect;
    public Scrollbar scrollBar;
    public Toggle MineToggle;
    public TMP_InputField inputField;  // ���� �Է�â
    AreaScript LastArea;

    TouchScreenKeyboard keyboard;   

    // Update is called once per frame
    void Update()
    {
        // �Է�â�� ��Ŀ���Ǿ����� ���� �� EnterŰ ������
        if (Input.GetKeyDown(KeyCode.Return) && inputField.isFocused == false)
            // �Է�â ��Ŀ�� Ȱ��ȭ
            inputField.ActivateInputField();
    }


    public void OnEndEditEventMethod()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdateChat();
        }
    }

    // enterŰ�� ��ư���� ����
    public void UpdateChat()
    {
        string text = inputField.text;

        if (text.Equals("")) return;

        Chat(true, text, "me", null);
        // Chat(false, text, "Ÿ��", null);

        inputField.text = "";   // inputField ���� �ʱ�ȭ
    }



    public void Chat(bool isSend, string text, string user, Texture2D picture)
    {
        if (text.Trim() == "") return;

        bool isBottom = scrollBar.value <= 0.00001f;


        // ���, ��������� ����� �ؽ�Ʈ ����
        AreaScript Area = Instantiate(isSend ? YellowArea : WhiteArea).GetComponent<AreaScript>();
        Area.transform.SetParent(ContentRect.transform, false);
        Area.BoxRect.sizeDelta = new Vector2(800, Area.BoxRect.sizeDelta.y);    // �ڽ� �ִ� ũ��
        Area.TextRect.GetComponent<Text>().text = text;
        Fit(Area.BoxRect);


        // �� �� �̻��̸� ũ�⸦ ���̰�, �� ���� �Ʒ��� �������� �ٷ� �� ũ�⸦ ���� 
        float X = Area.TextRect.sizeDelta.x + 42;
        float Y = Area.TextRect.sizeDelta.y;
        if (Y > 49)
        {
            for (int i = 0; i < 200; i++)
            {
                Area.BoxRect.sizeDelta = new Vector2(X - i * 2, Area.BoxRect.sizeDelta.y);
                Fit(Area.BoxRect);

                if (Y != Area.TextRect.sizeDelta.y) { Area.BoxRect.sizeDelta = new Vector2(X - (i * 2) + 2, Y); break; }
            }
        }
        else Area.BoxRect.sizeDelta = new Vector2(X, Y);


        // �ð� �������� �κ�
        DateTime t = DateTime.Now;
        Area.Time = t.ToString("yyyy-MM-dd-HH-mm");
        Area.User = user;


        // �ð� �����ִ� �κ�
        int hour = t.Hour;
        if (t.Hour == 0) hour = 12;
        else if (t.Hour > 12) hour -= 12;
        Area.TimeText.text =  hour + ":" + t.Minute.ToString("D2") + (t.Hour > 12 ? " PM " : " AM ") ;


        // ������ ���� ���
        bool isSame = LastArea != null && LastArea.Time == Area.Time && LastArea.User == Area.User;
        if (isSame) LastArea.TimeText.text = "";
        Area.Tail.SetActive(!isSame);


        // ������ ���� ��� (���)
        if (!isSend)
        {
            Area.UserImage.gameObject.SetActive(!isSame);
            Area.UserText.gameObject.SetActive(!isSame);
            Area.UserText.text = Area.User;
            if (picture != null) Area.UserImage.sprite = Sprite.Create(picture, new Rect(0, 0, picture.width, picture.height), new Vector2(0.5f, 0.5f));
        }



        Fit(Area.BoxRect);
        Fit(Area.AreaRect);
        Fit(ContentRect);
        LastArea = Area;


        // ��ũ�ѹٰ� �� �Ʒ��� ������
        Invoke("ScrollDelay", 0.03f);
    }


    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);


    void ScrollDelay() => scrollBar.value = 0;
}
