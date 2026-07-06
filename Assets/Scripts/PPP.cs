using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPP : MonoBehaviour
{
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("接地判定設定")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);

    [Header("ショット")]
    [SerializeField] private GameObject shotPrefab;

    private Rigidbody2D rb;
    private Animator animator; // ★Animatorコンポーネント用の変数を追加
    private float horizontalInput;
    private bool isGrounded;
    private bool jumpRequested;
    private bool shotCan = true;

    void Start()
    {
        // 自身のRigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();

        // ★自身のAnimatorを取得
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. 左右の入力受付
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // ★左右の向き（反転）の処理を呼び出す
        FlipCharacter();

        // ★Animatorの「stand」パラメータを制御
        // 条件：地面に足がついていて（isGrounded）、かつ移動入力がない（horizontalInputが0）とき
        if (animator != null)
        {
            bool isStanding = isGrounded && (horizontalInput == 0f);
            animator.SetBool("stand", isStanding);
        }

        // 2. ジャンプの入力受付
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        // ショットの入力受付
        if (Input.GetKeyDown(KeyCode.X) && shotCan)
        {
            shotCan = false;
            StartCoroutine(Shot());
        }
    }

    void FixedUpdate()
    {
        // 3. 接地判定
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        // 4. 左右移動の物理演算
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // 5. ジャンプの物理演算
        if (jumpRequested)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpRequested = false;
        }
    }

    // ★入力に応じてキャラクターの左右の向きを反転させるメソッド
    private void FlipCharacter()
    {
        // 右を入力していて、画像が左を向いている（あるいは初期状態）場合
        if (horizontalInput > 0f && transform.localScale.x < 0f)
        {
            // スケールを正（右向き）にする
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        // 左を入力していて、画像が右を向いている場合
        else if (horizontalInput < 0f && transform.localScale.x > 0f)
        {
            // スケールを負（左向き）にする
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    // Unityのエディタ画面で接地判定の範囲を可視化する
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        }
    }

    IEnumerator Shot()
    {
        GameObject shot = Instantiate(shotPrefab, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(1);
        shotCan = true;
    }
}