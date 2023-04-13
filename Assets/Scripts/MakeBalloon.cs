using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBalloon : MonoBehaviour

{
    //사용자 입력에 따라 풍선을 만드는 스크립트

    public GameObject balloon;
    GameObject balloonInstance;

    Vector3 beginPos;


    //발사 소리 효과
    public AudioClip ShootSnd;
    AudioSource ads;


    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        BalloonCtrl();
    }

    void BalloonCtrl()
    {
        //마우스 왼쪽을 클릭하는 순간 화면에 풍선 생성
        if (Input.GetMouseButtonDown(0))
        {
            beginPos = Input.mousePosition;
            //플레이어가 현재 바라보는 방향에서 공을 쏘아야 함으로 FirePos의 로컬 좌표계(위치, 회전)로 발사체 생성
            balloonInstance = Instantiate(balloon, transform.position ,transform.rotation);
            balloonInstance.transform.position = transform.position;

            //생성된 상태에서는 날리기전까지 정지하도록 설정
            balloonInstance.GetComponent<Rigidbody>().isKinematic = true;
        }
        //마우스 좌측 버튼을 누른 상태에서는 이동할 때 공이 플레이어 앞에 위치하도록 위치값을 바꿔줌
        //최대 크기가 4.3이고 오래 누를수록풍선의 크기가 커짐
        else if (Input.GetMouseButton(0))
        {
            balloonInstance.transform.position = transform.position;
            if (balloonInstance.transform.localScale.magnitude < 4.3) 
            {
                //Vector형식 -> float형식으로 써야함
                balloonInstance.transform.localScale += new Vector3(0.8f, 0.8f, 0.8f) * Time.deltaTime;
            }
            
        }
        //마우스 좌측 버튼에서 손을 때는 순간 버튼을 누른 시작지점과 차이를 계산해 해당 방향으로 날림
        else if (Input.GetMouseButtonUp(0))
        {
            Vector3 delta = Input.mousePosition - beginPos;

            //로컬 좌표계의 x, y, z축인 transform.right/up/forward 를 이용해 힘 벡터를 만듦
            //마우스 좌측 버튼을 누른 위치와 땐 위치의 차이를 벡터로 계산해서 마우스의 y 변화 값만큼 z방향 힘 작용 , y축으로 너무 올라가지 않게 조절(0.7f)
            //로컬 좌표계의 right에 마우스 x방향 움직임을 곱해주고 up에 마우스 y방향 움직임을 곱하고 z에도 해당 값을 절댓값으로 바꾸어 곱하고 모든 벡터를 더하면 날리고자하는 방향의 힘을 만들 수 있다.
            Vector3 force = transform.right * delta.x + transform.up * delta.y *  0.7f + transform.forward * Mathf.Abs(delta.y);
           
            balloonInstance.GetComponent<Rigidbody>().isKinematic = false;
            balloonInstance.GetComponent<Rigidbody>().AddForce(force * 5);

            //날리는 효과음 재생
            ads.PlayOneShot(ShootSnd);
        }
    }

}
