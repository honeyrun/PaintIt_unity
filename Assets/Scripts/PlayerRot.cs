using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRot : MonoBehaviour
{
    //플레이어의 상하 시점 변경을 조작하는 스크립트

    public float rotSpeed = 70;

    Vector3 AXIS_X = new Vector3(1, 0, 0);
   

    void Update()
    {
        Rotate();

    }


    void Rotate()
    {

        if (Input.GetMouseButton(1) == true)
        {
            //시점 상하이동만 따로 구현 -> 한 오브젝트에서 로컬x축 기준으로 회전하게 되면 플레이어의 이동에 문제 발생할 수 있음
            //플레이어안에 자식 오브젝트를 생성해 이 스크립트를 적용해 플레이어 이동과는 별개로 작동
            float my = Input.GetAxis("Mouse Y");
            Vector3 rotX = -AXIS_X * my * rotSpeed * Time.deltaTime;
            transform.Rotate(rotX, Space.Self);
        }
    }

}
