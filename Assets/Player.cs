using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    /*
    [Header("移動設定")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("接地判定設定")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);

    private PlayerInputs controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpRequested;

    private void Awake()
    {
        // ① 物理演算コンポーネントの取得はAwakeでやっておくのが安全です
        rb = GetComponent<Rigidbody2D>();

        // C#クラスのインスタンス化
        controls = new PlayerInputs();

        // ジャンプのイベント登録
        controls.Player.Jump.started += ctx => OnJumpRequested();
    }

    // ② 【重要】入力を有効化・無効化する処理
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        // 移動の入力値を毎フレーム読み取る
        moveInput = controls.Player.Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // ③ 接地判定（足元に地面があるかチェック）
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        // ④ 【重要】実際の移動・ジャンプの物理演算はFixedUpdateで行う
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (jumpRequested)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpRequested = false; // ジャンプ要求を消費
        }
    }

    // ジャンプのボタンが押された瞬間に呼ばれる
    private void OnJumpRequested()
    {
        // 接地している場合のみ、ジャンプを要求する
        if (isGrounded)
        {
            jumpRequested = true;
        }
    }

    // Unityエディタ上で接地判定の四角形を赤く表示する
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
        }
    }
    */
}