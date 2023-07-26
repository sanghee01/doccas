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
        // 마우스 왼쪽 버튼을 클릭했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 스크린 좌표를 월드 좌표로 변환합니다.
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            // Raycasting을 통해 오브젝트와 충돌을 감지합니다.
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
