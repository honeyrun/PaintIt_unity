using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    //게이지 형식의 점수 제어 스크립트

    public Image gauge;
    void Start()
    {
        gauge = GetComponent<Image>();
    }

    //외부에서 접근 가능하게 public으로 선언, 해당 함수를 외부에서 불러와서 게이지를 높임
    public void AddScore(float ratio)
    {
        gauge.fillAmount += ratio;
    }


}
