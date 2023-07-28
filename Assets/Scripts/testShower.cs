using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
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
    public GameObject Waterobj;
    public Button WaterBtn;
    public int score, count;
    private void Start()
    {
        WaterBtn = Waterobj.GetComponent<Button>();
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
        StartCoroutine(mulbangowl(3.0f));
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
    IEnumerator mulbangowl(float coolTime)
    {
        WaterBtn.enabled = false;
        Animobj.SetActive(true);
        while (coolTime > 1.0f)
        {
            coolTime -= Time.deltaTime;
            Debug.Log(coolTime);
            yield return new WaitForFixedUpdate();
        }
        CheckValue();
        Animobj.SetActive(false);
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
        WaterBtn.enabled = true;
    }
}