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
    private float horizontalInput;
    private bool isGrounded;
    private bool jumpRequested;
    private bool shotCan=true;

    void Start()
    {
        // 自身のRigidbody2Dを取得
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. 左右の入力受付（Edit > Project Settings > Input Managerの決定に従う）
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // 2. ジャンプの入力受付（Update内で行うことで入力の取りこぼしを防ぐ）
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        // 2. ジャンプの入力受付（Update内で行うことで入力の取りこぼしを防ぐ）
        if (Input.GetKeyDown(KeyCode.X)&&shotCan)
        {
            shotCan = false;
            StartCoroutine(Shot());
        }
    }

    void FixedUpdate()
    {
        // 3. 接地判定（足元に地面があるかチェック）
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
        GameObject shot = Instantiate(shotPrefab,this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(1);
        shotCan = true;
    }
}