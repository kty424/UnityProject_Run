using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }


    private void Update()
    {


        RaycastHit hit;
        
        //위로 박스 레이를 쏴서 플레이어가 맞는지 확인
        if(Physics.BoxCast(transform.position, new Vector3(1.5f, 0.1f, 0.5f), Vector3.up, out hit, Quaternion.identity, 3, LayerMask.GetMask("Player")))
        {
            //플레이어가 맞으면 플레이어의 y값과 자신의 y값을 비교 후 충돌 할지 말지 결정
            if (hit.collider.transform.position.y - transform.position.y >= 1)
            {
                coll.isTrigger = false;
            }
            else { coll.isTrigger = true; }

        }
        
    }
}
