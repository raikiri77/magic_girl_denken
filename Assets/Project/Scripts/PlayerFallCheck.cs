using UnityEngine;

public class PlayerFallCheck : MonoBehaviour
{
    [Header("-6")]
    [SerializeField] private float fallLimitY = -6f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
       
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (transform.position.y < fallLimitY)
        {
            Respawn();
        }
    }

    
    public void Respawn()
    {
        transform.position = startPosition;

        // 落下中のスピード（慣性）をゼロにする
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; 
        }
    }
}