using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class CChatManager : MonoBehaviour
{
    public GameObject YellowArea, WhiteArea;
    public RectTransform ContentRect;
    public Scrollbar scrollBar;
    public TMP_InputField inputField;  // ���� �Է�â
    AreaScript LastArea;
  

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
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdateChat();
        }
    }

    // enterŰ�� ��ư���� ����
    public async void UpdateChat()
    {
        string text = inputField.text;

        if (text.Equals("")) return;

        Chat(true, text, "me", null);
        inputField.text = "";   // inputField ���� �ʱ�ȭ

        // text��!!!!!!!!!!!!!!!!! �߿�

    }



    public void Chat(bool isSend, string text, string user, Texture2D picture)
    {
        if (text.Trim() == "") return;

        bool isBottom = scrollBar.value <= 0.00001f;


        // ä�� �ڽ� ������ ����� �ؽ�Ʈ ����
        AreaScript Area = Instantiate(isSend ? YellowArea : WhiteArea).GetComponent<AreaScript>();
        Area.transform.SetParent(ContentRect.transform, false);
        Area.BoxRect.sizeDelta = new Vector2(1000, Area.BoxRect.sizeDelta.y);    // �ڽ� �ִ� ũ��
        Area.TextRect.GetComponent<Text>().text = text;
        Fit(Area.BoxRect);


        // �� �� �̻��̸� ũ�⸦ ���̰�, �� ���� �Ʒ��� �������� �ٷ� �� ũ�⸦ ���� 



        // �ð� �������� �κ�
        DateTime t = DateTime.Now;
        Area.Time = t.ToString("yyyy-MM-dd-HH-mm");
        Area.User = user;


        // �ð� �����ִ� �κ�
        int hour = t.Hour;
        if (t.Hour == 0) hour = 12;
        else if (t.Hour > 12) hour -= 12;
        Area.TimeText.text =  hour + ":" + t.Minute.ToString("D2") + (t.Hour > 12 ? " PM " : " AM ") ;






        Fit(Area.BoxRect);
        Fit(Area.AreaRect);
        Fit(ContentRect);
        LastArea = Area;


        // ��ũ�ѹ� �� �Ʒ��� ������
        Invoke("ScrollDelay", 0.03f);
    }


    void Fit(RectTransform Rect) => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect);


    void ScrollDelay() => scrollBar.value = 0;
}
