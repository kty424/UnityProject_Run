using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Map : MonoBehaviour
{
  

    GameManager gm;

    private void Start()
    {
        gm = GameManager.Instance;
    }

    private void OnTriggerExit(Collider other)
    {
        //맵이 바뀌는걸 안보이게 하기위해 카메라밖에 나가면 맵을 연결
        if (other.CompareTag("CameraArea"))
        {
            //Debug.Log("Out");
            //맵을 소환하는 위치를 위해 현제 위치를 보냄
            gm.MapConnect(gameObject.transform.position );
            Destroy(gameObject);
        }
            
    }




}
