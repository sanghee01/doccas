using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAnimation : MonoBehaviour
{
    public Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        Debug.Log("���⿡ ���콺 Ŭ����");
        if (anim.GetBool("IsTouched") == false) 
        {
            anim.SetBool("IsTouched", true);
            Debug.Log(anim.GetBool("IsTouched"));
        }
        else if(anim.GetBool("IsTouched") == true){
            anim.SetBool("IsTouched", false);
        }
    }
}
