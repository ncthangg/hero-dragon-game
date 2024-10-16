
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;
    private float direction;
    private bool hit;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private Vector3 startPosition;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (hit) return;
        if (Vector3.Distance(startPosition, transform.position) < range)
        {
            float movementSpeed = speed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }
        else
        {
            OutOfRange();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Item")
        {
            OutOfRange();
        }

    }

    private void OutOfRange()
    {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("explode");

        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
    public void SetDirection(float _direction)
    {
        if (boxCollider == null)
            return;

        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

        startPosition = transform.position;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
