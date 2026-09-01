using UnityEngine;

public class DeadZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れたのがプレイヤーの場合
        if (collision.CompareTag("Player"))
        {
            
            PlayerFallCheck player = collision.GetComponent<PlayerFallCheck>();
            if (player != null)
            {
                player.SendMessage("Respawn");
            }
        }
    }
}
