using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target; // A árvore
    public Transform player;
    public float speed = 2f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Se estiver muito perto do player, não anda, só ataca
        if (player != null && Vector2.Distance(transform.position, player.position) < 1.2f)
        {
            rb.linearVelocity = Vector2.zero;
            if (Time.time > lastAttackTime + attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
            animator.Play("Enemy_Atack");
            return;
        }

        // Anda até a árvore
        if (target != null)
        {
            Vector2 direction = ((Vector2)target.position - rb.position).normalized;
            rb.linearVelocity = direction * speed;
            animator.SetFloat("Speed", Mathf.Abs(direction.x));

            // Flip do sprite
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
                sprite.flipX = direction.x < 0;

            // Chegou na árvore?
            if (Vector2.Distance(transform.position, target.position) < 0.3f)
            {
                GameManager gm = FindObjectOfType<GameManager>();
                if (gm != null) gm.GameOver();
                Destroy(gameObject);
            }
        }
    }


    void AttackPlayer()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }

        Animator playerAnim = player.GetComponent<Animator>();
        if (playerAnim != null)
        {
            playerAnim.SetTrigger("Dead"); // nome do trigger na animação do player
        }

        Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();
        if (playerRb != null)
        {
            Vector2 force = ((Vector2)player.position - (Vector2)transform.position).normalized * 5f;
            playerRb.AddForce(force, ForceMode2D.Impulse);
        }

    }

    // Opcional: também faz dano quando colidir, para garantir
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AttackPlayer();
        }
        if (other.gameObject.CompareTag("Tree"))
        {
            TreeBase tree = other.gameObject.GetComponent<TreeBase>();
            if (tree != null)
            {
                tree.DestroyTree();
            }
            Destroy(gameObject);
        }
    }

}
