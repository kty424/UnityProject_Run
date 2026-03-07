using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumpCount = 2; // 최대 점프 횟수

    private int jumpCount = 0;
    private Rigidbody rb;

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
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = maxJumpCount; // 땅에 닿으면 점프 횟수 초기화
        }
    }
}
