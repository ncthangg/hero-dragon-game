using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;
    private Animator anim;
    private bool dead;

    [Header("iFrame when has damaged")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer _sprite;

    [Header("Sound")]
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip dieSound;

    [Header("UI Manager")]
    private UIManager uiManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDame(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            //SoundManager.instance.PlaySound(hurtSound);
            FindObjectOfType<SoundManager>().Play("hurt");

            anim.SetTrigger("hurt");
            healthBar.SetHealth(currentHealth);

            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                //SoundManager.instance.PlaySound(dieSound);
                FindObjectOfType<SoundManager>().Play("death");

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");
                healthBar.SetHealth(currentHealth);
                dead = true;
                StopMovement();
                uiManager.GameOver();
            }
        }
    }
    public void StopMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

    public void AddHealth(int _value)
    {
        var hearthFuture = currentHealth + _value;
        if (currentHealth < maxHealth)
        {
            if (hearthFuture > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += _value;
                healthBar.SetHealth(currentHealth);
            }
        }
    }

    public IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(3, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            _sprite.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            _sprite.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 10, false);
    }

}
