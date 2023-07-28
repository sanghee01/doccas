using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testfeeder : MonoBehaviour
{
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
    Button FirstBtn, SecondBtn, ThirdBtn, FourthBtn;

    private void Start()
    {
        FirstBtn = FirstObj.GetComponent<Button>();
        SecondBtn = SecondObj.GetComponent<Button>();
        ThirdBtn = ThirdObj.GetComponent<Button>();
        FourthBtn = FourthObj.GetComponent<Button>();
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

    public void One_Food() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 10;
        StartCoroutine(mulbangowl());
        slide.value += score;
        // DB��� - 1

    }

    public void Two_Food()
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 20;
        StartCoroutine(mulbangowl());
        slide.value += score;
        // DB��� - 1

    }

    public void One_Snack()
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 5;
        StartCoroutine(mulbangowl());
        slide.value += score;

        // DB��� - 1

    }

    public void Two_Snack() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        First.SetActive(false);
        Second.SetActive(true);
        Third.SetActive(false);
        Fourth.SetActive(false);
        score = 10;
        StartCoroutine(mulbangowl());
        slide.value += score;
        // DB��� - 1

    }
    IEnumerator mulbangowl()
    {
        disableBtn();
        yield return new WaitForSeconds(3.0f);
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
        FirstBtn.enabled = false;
        SecondBtn.enabled = false;
        ThirdBtn.enabled = false;
        FourthBtn.enabled = false;
    }
    public void ableBtn()
    {
        FirstBtn.enabled = true;
        SecondBtn.enabled = true;
        ThirdBtn.enabled = true;
        FourthBtn.enabled = true;
    }
}

