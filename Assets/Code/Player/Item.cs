using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템의 기본 클래스
public class Item : MonoBehaviour
{
    public virtual void Use(GameObject player)
    {
        Debug.Log("아이템 사용");
    }
}
