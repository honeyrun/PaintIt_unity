using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGen: MonoBehaviour
{
    //음식 Prefabs을 담을 게임 오브젝트 배열
    public GameObject[] FoodObjs;

    float curTime = 0.0f; 

    void Start()
    {
    }

    void Update()
    {
        curTime += Time.deltaTime;

        FoodGenerate();
    }

    //음식 생성 함수
    void FoodGenerate()
    {
        //0.8초마다 무작위 음식이 생성된다.
        if (curTime > 0.8f)
        {

            //랜덤 음식 오브젝트 생성
            //Random.Range(0, 7) >> 0 ~ 6 까지 정수중 랜덤 1개
            GameObject obj = FoodObjs[Random.Range(0, 7)];
            //랜덤 위치, 방향 지정
            Vector3 objPos = new Vector3(Random.Range(-85,90), 110, Random.Range(-60, 60));
            Vector3 objRot = new Vector3(Random.Range(-60, 60), Random.Range(-90, 90), Random.Range(-60, 60));
            obj.transform.position = objPos;
            obj.transform.Rotate(objRot);

            //음식 오브젝트 생성
            Instantiate(obj);

            //시간 초기화
            curTime = 0;
            
        }

    }


}
