using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어가 거대해지고 장애물을 날려버리는 아이템
// (애니메이션 재생속도가 느려지는 건 추가할것)
public class GiantItem : Item
{
    [SerializeField] float duration = 5f; 
    [SerializeField] float scaleMultiplier = 2f;

    public override void Use(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (movement != null)
        {
            movement.StartCoroutine(GiantMode(movement));
        }

        Destroy(gameObject);
    }

    private IEnumerator GiantMode(PlayerMovement movement)
    {
        movement.isGiantActive = true;

        // 일정 시간 동안 localScale가 scaleMultiplier배로 커지도록 설정
        Vector3 originalScale = movement.transform.localScale;
        movement.transform.localScale = originalScale * scaleMultiplier;

        yield return new WaitForSeconds(duration);

        movement.transform.localScale = originalScale;
        movement.isGiantActive = false;
    }
}
