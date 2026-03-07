using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어의 속도가 빨라지면서 장애물을 파괴하는 아이템
public class BoosterItem : Item
{
    public float boostAmount = 5f;
    public float duration = 3f;

    public override void Use(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        
        if (movement != null)
        {
            movement.StartCoroutine(SpeedBoost(movement));
        }

        Destroy(gameObject);
    }

    // 일정 시간 동안 속도 증가, 시간 지나면 원래 속도
    IEnumerator SpeedBoost(PlayerMovement player)
    {
        player.MoveSpeed += boostAmount;
        player.isBoosterActive = true;

        yield return new WaitForSeconds(duration);

        player.MoveSpeed -= boostAmount;
        player.isBoosterActive = false;
    }
}
