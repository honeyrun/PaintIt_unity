using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //플레이어를 조작하는 스크립트

    //이동속도, 회전 속도
    public float moveSpeed = 10;
    public float rotSpeed = 70;
    //점프력
    public float force = 700;


    Vector3 AXIS_X = new Vector3(1, 0, 0);
    Vector3 AXIS_Y = new Vector3(0, 1, 0);
    Vector3 AXIS_Z = new Vector3(0, 0, 1);


    int jumpCount = 2;

    Transform tr;
    Rigidbody rb;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }



    void Move()
    {
        //키보드 방향키, WASD를 누르면 조작가능, 플레이어의 상하좌우 이동 담당
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDir = (AXIS_X * h + AXIS_Z * v).normalized;
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    
    
  
    void Rotate()
    {     
        //마우스 오른쪽 버튼을 누른 상태에서만 시점 조작 가능
        if (Input.GetMouseButton(1) == true) {

            //월드 좌표계 Y축 기준 회전만 적용 -> 플레이어 좌우 시점 변경
            float mx = Input.GetAxis("Mouse X");
            Vector3 rotY = AXIS_Y * mx * rotSpeed * Time.deltaTime;
            tr.Rotate(rotY, Space.World);

        }

    }


    void Jump()
    {
        //최대 2번까지 점프 가능, 스페이스 키로 조작
        if (jumpCount > 0 && Input.GetKeyDown("space"))
        {
            rb.AddForce(0, force, 0);
            --jumpCount;
        }
        //점프 횟수가 0이 됐을 때 플레이어의 y좌표가 1.3보다 낮다면 점프 횟수 2로 설정
        else if (jumpCount <= 0 )
        {
            if (transform.position.y < 1.3)
            {
                jumpCount = 2;
            }
        }
    }



    void OnDisable()
    {
        //해당 스크립트가 비활성화 됐을때 실행되는 함수
        rb.velocity = Vector3.zero;
        rb.AddForce(0, 1000, 0);
    }

}
