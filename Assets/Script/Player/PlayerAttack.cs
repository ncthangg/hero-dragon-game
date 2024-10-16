using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform firePoint;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Sound")]
    [SerializeField] private AudioClip attackSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {

        //SoundManager.instance.PlaySound(attackSound);
        FindObjectOfType<SoundManager>().Play("fireball");

        animator.SetTrigger("attack");
        cooldownTimer = 0;

        SpawnFireball();
    }


    private void SpawnFireball()
    {
        // Instantiate a new fireball at the firePoint position
        GameObject newFireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        // Set direction or any other properties here
        newFireball.GetComponent<Projectile>().SetDirection(Math.Sign(transform.localScale.x));

    }


}
