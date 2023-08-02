using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
public class dog1 : MonoBehaviour
{
    public MainSceneDB MainSceneDB;
    public Slider slide1; // �ູ��
    public Slider slide2; // ������
    public Slider slide3; //��å
    public Slider slide4; //���
    public GameObject First; // �⺻ ����(�ູ�� 25�̻�)
    public GameObject Second; // ���»���
    public GameObject n1;
    public GameObject n2;
    public GameObject n4;

    private void Awake()
    {
        MainSceneDB = GameObject.Find("Database").GetComponent<MainSceneDB>();
        MainSceneDB.DBMainSceneInitialize();
        First.SetActive(false);
        Second.SetActive(false);
        n1.SetActive(false);
        n2.SetActive(false);
        n4.SetActive(false);
        if (slide1.value < 25) //���� 25�̸�
        {
            First.SetActive(false);
            Second.SetActive(true);
            n1.SetActive(true);
        }
        else if (slide2.value < 25)
        {
            First.SetActive(false);
            Second.SetActive(true);
            n2.SetActive(true);
        }
        else if (slide4.value < 25)
        {
            First.SetActive(false);
            Second.SetActive(true);
            n4.SetActive(true);
        }
        else 
        {
            First.SetActive(true);
            Second.SetActive(false);
        }
    }
}