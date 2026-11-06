using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    private Animator animator;
    private Vector2 lastDirection = Vector2.down;
    public Transform player;
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float stoppingDistance = 0.8f;
    public int damage = 10;
    public float attackCooldown = 1.5f;

    private float nextAttackTime;
    private Health playerHealth;

    private Rigidbody2D rb;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(
            rb.position, player.position);
        bool isChasing = distance <= detectionRange &&
                 distance > stoppingDistance;

        animator.SetBool("isMoving", isChasing);

        if (isChasing)
        {       
            Vector2 chaseDirection = ((Vector2)player.position - rb.position).normalized;

            lastDirection = chaseDirection;
        }

        animator.SetFloat("MoveX", lastDirection.x);
        animator.SetFloat("MoveY", lastDirection.y);
        
        if (distance <= stoppingDistance && Time.time >= nextAttackTime)
        {
            if (playerHealth == null) playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                animator.SetTrigger("Attack");
                playerHealth.TakeDamage(damage, transform.position);
                nextAttackTime = Time.time + attackCooldown;
            }
        }

        if (distance > detectionRange ||
            distance <= stoppingDistance)
            return;

        Vector2 direction =
            ((Vector2)player.position - rb.position).normalized;

        Vector2 newPosition =
            rb.position + direction * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}