using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBalloon : MonoBehaviour
{
    //풍선이 해당 오브젝트에 닿으면 터지게 함/지형, 월드의 집 오브젝트 등에 들어가는 스크립트

    //풍선이 터질 때 재생되는 사운드 클립
    AudioSource ads;

    public GameObject paintEffect; //paint 파티클

    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        //tag가 풍선임을 확인한다.
        if (coll.collider.tag == "BALLOON")
        {
            //파티클 오브젝트 생성
            GameObject paint = Instantiate(paintEffect);
            paint.transform.position = coll.transform.position;

            ads.Play();

            //파티클은 7초 뒤에 삭제
            Destroy(paint, 7);

            //풍선은 즉시 없어짐
            Destroy(coll.gameObject);

        }
    }
}
