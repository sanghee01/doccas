using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testShower : MonoBehaviour
{
    public Slider slide;
    public GameObject First; // �⺻ ����(û�ᵵ 50�̻�)
    public GameObject Second; // �������� ����(��ǰ����)
    public GameObject Third; // �ǼۻǼ� ����(if û�ᵵ 50�̻� && �����Ϸ�)=> ������ 
    public GameObject Fourth; // �������� ����(û�ᵵ 50�̸�)
    public GameObject Animobj;
    public int score, count;
    private void Start()
    {
        First.SetActive(true);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        count = 0;
        Animobj = GameObject.Find("BackGroundCanvus").transform.Find("Shower").gameObject;
        Animobj.SetActive(false);
    }
    public void One_Shampoo() // ��ư Ŭ�� �̺�Ʈ
    {
        count++;
        SettingImg();
        score = 10;
        slide.value += score;
        // DB��� - 1
    }
    public void Two_Shampoo()
    {
        count++;
        SettingImg();
        score = 20;
        slide.value += score;
        // DB��� - 1
    }
    public void Three_Shampoo()
    {
        count++;
        SettingImg();
        score = 30;
        slide.value += score;
        // DB��� - 1
    }
    public void Watering()
    {
        StartCoroutine(mulbangowl());
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
        yield return new WaitForSeconds(3.0f);
        Animobj.SetActive(false);
        CheckValue();
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
    }
}