using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllMobileKey : MonoBehaviour
{
    void Update()
    {
        /*        if (Application.platform == RuntimePlatform.Android)
                {
                    if (Input.GetKey(KeyCode.Home)) // Ȩ Ű
                    {

                    }
                    else if (Input.GetKey(KeyCode.Escape)) // �ڷΰ��� Ű
                    {
                        SceneManager.LoadScene("MainScene");
                    }
                    else if (Input.GetKey(KeyCode.Menu)) // �޴� Ű
                    {

                    }
                }*/
        if (Input.GetKey(KeyCode.Tab))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
