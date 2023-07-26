using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UI;

public class DogAnimation : MonoBehaviour
{
    public Animator anim;
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ�մϴ�.
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            // Raycasting�� ���� ������Ʈ�� �浹�� �����մϴ�.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.name == "Dog")
                {
                    anim.SetBool("isTouched", true);
                    StartCoroutine(WaitForSecond());
                }
            }
        }
    }
    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("isTouched", false);
    }
}
