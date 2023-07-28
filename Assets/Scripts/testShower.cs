using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
public class testShower : MonoBehaviour
{
    public Slider slide;
    public GameObject First; // �⺻ ����(û�ᵵ 50�̻�)
    public GameObject Second; // �������� ����(��ǰ����)
    public GameObject Third; // �ǼۻǼ� ����(if û�ᵵ 50�̻� && �����Ϸ�)=> ������ 
    public GameObject Fourth; // �������� ����(û�ᵵ 50�̸�)
    public GameObject Animobj;
    public int score, count;
    // ��ư obj
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
        if (slide.value >= 50)
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
        count = 0;
        Animobj = GameObject.Find("BackGroundCanvus").transform.Find("Shower").gameObject;
        Animobj.SetActive(false);
    }
    public void One_Shampoo() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        SettingImg();
        StartCoroutine(Wait());
        score = 10;
        slide.value += score;
        // DB��� - 1
    }
    public void Two_Shampoo()
    {
        count++;
        SettingImg();
        StartCoroutine(Wait());
        score = 20;
        slide.value += score;
        // DB��� - 1
    }
    public void Three_Shampoo()
    {
        count++;
        SettingImg();
        StartCoroutine(Wait());
        score = 30;
        slide.value += score;
        // DB��� - 1
    }
    public void Watering()
    {
        StartCoroutine(mulbangowl());
        CheckValue();
    }
    public void SettingImg() // ������
    {
        if (count >= 1)
        {
            First.SetActive(false);
            Second.SetActive(true);
            Third.SetActive(false);
            Fourth.SetActive(false);
        }
    }
    IEnumerator mulbangowl()
    {
        Animobj.SetActive(true);
        disableBtn();
        yield return new WaitForSeconds(3);
        Animobj.SetActive(false);
    }
    IEnumerator Wait(){
        disableBtn();
        yield return new WaitForSeconds(3);
        ableBtn();
    }
    public void CheckValue()
    {
        if (slide.value < 50) // ���� �� û�ᵵ 50�̸�
        {
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(false);
            Fourth.SetActive(true);
        }
        else // ���� �� û�ᵵ 50�̻�
        {
            First.SetActive(false);
            Second.SetActive(false);
            Third.SetActive(true);
            Fourth.SetActive(false);
            count = 0;
        }
        ableBtn();
    }
    public void disableBtn(){
        FirstBtn.enabled = false;
        SecondBtn.enabled = false;
        ThirdBtn.enabled = false;
        FourthBtn.enabled = false;
    }
    public void ableBtn(){
        FirstBtn.enabled = true;
        SecondBtn.enabled = true;
        ThirdBtn.enabled = true;
        FourthBtn.enabled = true;
    }
}