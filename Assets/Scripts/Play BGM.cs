using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager:MonoBehaviour
{
	//sound를 한곳에서 관리할 수 있도록 singleton 패턴
    private static SoundManager _instance;
    
    public AudioSource bgSound;
    public AudioClip[] bgList;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        //scene이 전환되어도 object가 없어지지않도록함
        DontDestroyOnLoad(gameObject);


    }

	//scene이 로딩됐을때 해당 scene 이름과 같은 이름의 bgm 재생
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        for(int i=0; i<bgList.Length; i++)
        {
            if(arg0.name == bgList[i].name)
            {
            	BgSoundPlay(bgList[i]);
            }

        }
    } 
    
  
	//배경음 플레이 함수
    public void BgSoundPlay( AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.1f;
        bgSound.Play();
    }
}