using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    [SerializeField] private AudioClip healthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SoundManager.instance.PlaySound(healthSound);
        FindObjectOfType<SoundManager>().Play("life");
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().AddHealth(health);
            gameObject.SetActive(false);
        }
    }
}
