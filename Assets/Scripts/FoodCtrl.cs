using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCtrl : MonoBehaviour
{
    // 하늘에서 무작위로 생성되는 음식의 충돌처리, 메테리얼 변경 등을 담당함.

    public Material paintMat;
    public ScoreMng sm;

    //풍선이 터질 때 재생되는 사운드 클립
    AudioSource ads;

    public GameObject paintEffect; //paint 파티클

  
    void Start()
    {
        ads = GetComponent<AudioSource>();

        //food는 clone으로 생성되는 객체기 때문에 ScoreMng를 public으로 선언 시 연결할 수 없다 -> Hierarchy상에서 찾아오는 방식 사용
        sm = GameObject.Find("Score").GetComponent<ScoreMng>();

    }


    void OnCollisionEnter(Collision coll)
    {
        //음식에 풍선이 닿았고, 음식 오브젝트 <FoodCtrl>가 유효한 상태라면 해당 효과 적용
        if (coll.collider.CompareTag("BALLOON") && GetComponent<FoodCtrl>().enabled == true)
        {

            //풍선이 터지면서 페인트가 퍼지는 효과 파티클 오브젝트 생성
            GameObject paint = Instantiate(paintEffect);
            paint.transform.position = coll.transform.position;

            //풍선이 터지는 소리 재생
            ads.Play();

            //파티클 7초 뒤에 삭제
            Destroy(paint, 7);

            //풍선 오브젝트는 닿자마자 삭제
            Destroy(coll.gameObject);


            //점수를 제어하는 오브젝트를 가져와 풍선을 맞출 때 마다 점수 올림, 15번 맞추면 게임 클리어
            // (실수 / 정수) 의 결과는 실수 값, 자동 형변환
            sm.AddScore(1.0f / 15);

            //음식 오브젝트의 <FoodCtrl>를 비활성화 시킴
            GetComponent<FoodCtrl>().enabled = false;
        }

        //음식이 지형에 닿았을 경우 0.3초 뒤 삭제
        else if (coll.collider.CompareTag("TERRAIN") && GetComponent<FoodCtrl>().enabled == true )
        {
            Destroy(gameObject, 0.2f);
        }
    }


    //음식 오브젝트 <FoodCtrl>가 유효하지 않는 상태라면 페인트가 칠해진 Material로 바꿈
    void OnDisable()
    {
        GetComponent<Renderer>().material = paintMat;
    }

}
