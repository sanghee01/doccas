using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testfeeder : MonoBehaviour
{
    public FeedDB FeedDb;
    public Slider slide;
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject Fourth;
    /*public GameObject Animobj;*/
    public int score, count;
    /* ��ư ������Ʈ�� */
    public GameObject FirstObj;
    public GameObject SecondObj;
    public GameObject ThirdObj;
    public GameObject FourthObj;
    // �̹��� ���� ������ ���� �̹��� obj
    public Image Firstimg;
    public Image Secondimg;
    public Image Thirdimg;
    public Image Fourthimg;

    Button FirstBtn, SecondBtn, ThirdBtn, FourthBtn;
    //  �̹��� ���� ������ ���� Color ��ü
    Color FirstCo, SecondCo, ThirdCo, FourthCo;

    private void Awake()
    {
        FeedDb = GameObject.Find("Database").GetComponent<FeedDB>();
        FeedDb.DBFeedSceneInitialize();
        if (slide.value < 60) //��� ���� 60�̸��̸�
        {
            First.SetActive(true); //1�� ����¸���� ON
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(false);
            count = 0;
        }
        else //��� ���� 60�̻�
        {
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(true);
            count = 0;
        }
    }
    private void Start()
    {
        FirstBtn = FirstObj.GetComponent<Button>();
        SecondBtn = SecondObj.GetComponent<Button>();
        ThirdBtn = ThirdObj.GetComponent<Button>();
        FourthBtn = FourthObj.GetComponent<Button>();
        FirstCo = Firstimg.color;
        SecondCo = Secondimg.color;
        ThirdCo = Thirdimg.color;
        FourthCo = Fourthimg.color;
    }

    public void One_Food() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 10;
        StartCoroutine(Wait(3.0f));
        slide.value += score;

        // DB��� - 1
        FeedDb.feed1Clicked();
    }

    public void Two_Food()
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 20;
        StartCoroutine(Wait(3.0f));
        slide.value += score;
        // DB��� - 1
        FeedDb.feed2Clicked();
    }

    public void One_Snack()
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 5;
        StartCoroutine(Wait(3.0f));
        slide.value += score;

        // DB��� - 1
        FeedDb.feed3Clicked();

    }

    public void Two_Snack() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 10;
        StartCoroutine(Wait(3.0f));
        slide.value += score;
        // DB��� - 1
        FeedDb.feed4Clicked();

    }
    IEnumerator Wait(float coolTime)
    {
        disableBtn();
        float filledTime = 0f;
        while (filledTime <= coolTime)
        {
            yield return new WaitForFixedUpdate();
            filledTime += Time.deltaTime;
            Firstimg.fillAmount = filledTime / coolTime;
            Secondimg.fillAmount = filledTime / coolTime;
            Thirdimg.fillAmount = filledTime / coolTime;
            Fourthimg.fillAmount = filledTime / coolTime;
        }
        valuecheck();
    }

    public void valuecheck() // ���� �����̴��� üŷ
    {
        if (slide.value < 60)
        {
            First.SetActive(true);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(false);
        }
        else
        {
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(true);
        }
        ableBtn();
    }
    public void disableBtn()
    {
        SetInvisable();
        FirstBtn.enabled = false;
        SecondBtn.enabled = false;
        ThirdBtn.enabled = false;
        FourthBtn.enabled = false;
    }
    public void ableBtn()
    {
        Setvisable();
        FirstBtn.enabled = true;
        SecondBtn.enabled = true;
        ThirdBtn.enabled = true;
        FourthBtn.enabled = true;
    }

    public void SetInvisable()
    {
        // ��Ȱ��ȭ ���� ����
        FirstCo.a = 0.5f;
        SecondCo.a = 0.5f;
        ThirdCo.a = 0.5f;
        FourthCo.a = 0.5f;
        Firstimg.color = FirstCo;
        Secondimg.color = SecondCo;
        Thirdimg.color = ThirdCo;
        Fourthimg.color = FourthCo;
    }
    public void Setvisable()
    {
        // Ȱ��ȭ ���� ����
        FirstCo.a = 1.0f;
        SecondCo.a = 1.0f;
        ThirdCo.a = 1.0f;
        FourthCo.a = 1.0f;
        Firstimg.color = FirstCo;
        Secondimg.color = SecondCo;
        Thirdimg.color = ThirdCo;
        Fourthimg.color = FourthCo;
    }
}

