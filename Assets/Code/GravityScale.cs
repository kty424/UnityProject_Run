using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScale : MonoBehaviour
{

    Rigidbody rd;
    // 중력 스케일
    public float gravity_scale = 1;
    // 중력 가속도
    const float gravity = -9.8f; 

    private void Start()
    {
       rd = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        // 매 프레임 중력 가속도 만큼 가속도로 힘을 줌
        rd.AddForce(0,gravity * gravity_scale ,0,ForceMode.Acceleration); 



    }
}
