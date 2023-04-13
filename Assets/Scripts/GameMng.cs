using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    //게임의 성공, 실패를 조작하는 스크립트

    public GameObject gameOver;
    public GameObject gameClear;
    public ScoreMng gameState;

    //Update함수 내에서 소리를 한 번만 재생해줄 제어변수
    bool playSndOneTime = false;

    public GameObject player;
    public GameObject foodGen;

    public AudioClip GameClearSound;
    public AudioClip GameOverSound;
    AudioSource ads;

    Text timeText;
    //게임 종료 시간 >> 지정 시간내에 미션을 완료하지 못하면 게임 오버
    float curTime = 180.0f; 

    void Start()
    {
        timeText = GetComponent<Text>();
        ads = GetComponent<AudioSource>();
    }

    void Update()
    {
        //남은 시간이 0보다 작고, 게이지를 다 채우지 못하면 게임오버
        if (curTime < 0.0f && gameState.gauge.fillAmount < 1)
        {
            //게임 오버 이미지를 화면에 띄움
            gameOver.SetActive(true);
            //게임 오버 소리를 한번만 재생
            if (playSndOneTime == false)
            {
                ads.PlayOneShot(GameOverSound);
                playSndOneTime = true;
            }
            
            timeText.text = "0";
            //플레이어와 음식 생성 스크립트를 비활성화 한다.
            player.GetComponent<PlayerCtrl>().enabled = false;
            foodGen.GetComponent<FoodGen>().enabled = false;
        }

        //게이지를 다 채우면 게임 클리어
        else if (gameState.gauge.fillAmount >= 1)
        {
            gameClear.SetActive(true);
            if (playSndOneTime == false)
            {
                ads.PlayOneShot(GameClearSound);
                playSndOneTime = true;
            }
            timeText.text = timeText.text;
            player.GetComponent<PlayerCtrl>().enabled = false;
            foodGen.GetComponent<FoodGen>().enabled = false;
        }
        else 
        {
            //게임 클리어, 게임 오버 어느 상태도 아니라면 남은 시간을 줄이고 화면에 표시함.
            curTime -= Time.deltaTime;
            timeText.text = string.Format("{0:N2}", curTime);
        }
    }



}
