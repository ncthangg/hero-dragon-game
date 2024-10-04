using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lucDay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDame(damage);
        }

        Rigidbody2D playerRb = collision.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            // Tính toán hướng đẩy ngược lại với hướng mà Player đang đối diện
            float playerDirection = Mathf.Sign(collision.transform.localScale.x); // Lấy hướng mà Player đang đối diện (1 hoặc -1)
            Debug.Log(playerDirection);
            // Áp dụng lực đẩy theo hướng ngược lại
            Vector2 knockback = new Vector2(playerDirection * lucDay * 0.5f, lucDay * 0.5f); // Lực đẩy ngược lại và một chút hướng lên trên
            playerRb.AddForce(knockback, ForceMode2D.Impulse); // Apply impulse force
            Debug.Log("da day lui");
        }
    }

}
