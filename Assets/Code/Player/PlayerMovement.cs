using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 움직임 관련 스크립트
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumpCount = 2; // 최대 점프 횟수

    [HideInInspector] public bool isBoosterActive = false;
    [HideInInspector] public bool isGiantActive = false;

    private int jumpCount = 0;
    private Rigidbody rb;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpCount = maxJumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            // 현재 속도 유지하기 위해 new Vector3로 x축 속도 유지, y축에 jumpForce 적용
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
            jumpCount--;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveSpeed, rb.velocity.y, 0f);
    }

    // 아이템과 충돌 시 아이템 즉시 사용
    void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            item.Use(gameObject);
        }
    }

    // 여러가지 충돌 처리 - 땅과 장애물
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumpCount;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (isBoosterActive) // 부스터 상태에서는 장애물 파괴
            {
                Destroy(collision.gameObject);
            }
            else if (isGiantActive) // 거대화 상태에서는 장애물 밀어내기
            {
                // 랜덤한 힘으로 장애물 밀어내기 (거대화 상태에서만)
                float obstaclePushForce = Random.Range(1.5f, 5f);
                Rigidbody obstacleRb = collision.gameObject.GetComponent<Rigidbody>();
                Collider obstacleCol = collision.gameObject.GetComponent<Collider>();

                if (obstacleRb != null)
                {
                    if (obstacleCol != null)
                        obstacleCol.enabled = false;

                    // ForceMode.Impulse : 빠르게 힘을 가하는 방식, 순간적으로 큰 힘을 가할 때 사용
                    obstacleRb.AddForce(new Vector3(0f, obstaclePushForce, -10f), ForceMode.Impulse);
                    Destroy(collision.gameObject, 3f);
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
