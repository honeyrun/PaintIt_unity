using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
    //맨 처음 게임을 시작하면 나타나는 화면의 버튼 조작을 위한 스크립트

    //버튼을 누르면 재생되는 사운드 클립
    public AudioClip ButtonSnd;
    AudioSource ads;

    public Image instruction;
    public GameObject CloseBtn;


    void Start()
    {
        instruction.enabled = false;
        CloseBtn.SetActive(false);
        ads = GetComponent<AudioSource>();
    }

    //게임 시작 버튼을 누르면 Main 씬으로 전환함.
    public void ChangeMainScene()
    {
        ads.PlayOneShot(ButtonSnd);
        SceneManager.LoadScene("MainScene");
    }

    //게임 방법 버튼을 누르면 조작 방법을 알려주는 이미지를 표시함.
    public void ShowInstruction()
    {
        ads.PlayOneShot(ButtonSnd);
        instruction.enabled = true;
        CloseBtn.SetActive(true);
    }

    //'X' 버튼을 통해 조작 방법 이미지를 비활성화 함.
    public void CloseInstruction()
    {
        ads.PlayOneShot(ButtonSnd);
        instruction.enabled = false;
        CloseBtn.SetActive(false);
    }

}
