using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    [Header("Sound")]
    [SerializeField] private AudioClip jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        // lật khi chuyển hướng trái/phải
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        // chạy
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", isGrounded());

        // nhảy tường
        if (wallJumpCooldown < 0.2f)
        {

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onwall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 5;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
                if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
                    //SoundManager.instance.PlaySound(jumpSound);
                    FindObjectOfType<SoundManager>().Play("jump");


            }

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
            wallJumpCooldown += Time.deltaTime;

    }
    void Jump()
    {

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            animator.SetTrigger("jump");
        }
        // else if (onwall() && !isGrounded())
        // {
        //     if (horizontalInput == 0)
        //     {
        //         body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
        //         transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), (transform.localScale.y), (transform.localScale.z));
        //     }
        //     else
        //         body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

        //     wallJumpCooldown = 0;

        // }

    }

    bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    bool onwall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onwall();
    }
}
