using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpForce = 10f;

    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public GameObject attackZone;

    public bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        // Corrida
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Movimento
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Flip do sprite
        if (move > 0)
            sprite.flipX = false;
        else if (move < 0)
            sprite.flipX = true;

        // Anima��es
        animator.SetFloat("Speed", Mathf.Abs(move));

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump"); // <--- nome deve ser exatamente "Jump"
        }

        // Ataque
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Atack");
            attackZone.SetActive(true);
            Invoke("DisableAttackZone", 0.3f); // tempo curto de ataque
        }

        // Defend
        if (Input.GetKey(KeyCode.Mouse1)) // Enquanto pressionado
        {
            animator.Play("Defend");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.Play("Walk"); // Se estiver a andar
        }

        //if (Input.GetMouseButtonDown(0)) // botão esquerdo
        //{
        //    animator.Play("Attack");
        //    attackZone.SetActive(true);
        //    Invoke("DisableAttackZone", 0.3f); // ativa por 0.3 segundos
        //}
        //Vector3 attackPos = attackZone.transform.localPosition;
        //attackPos.x = sprite.flipX ? -0.5f : 0.5f;
        //attackZone.transform.localPosition = attackPos;
    }

    void DisableAttackZone()
    {
        attackZone.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal"))
        {
            FindObjectOfType<GameManager>().Win();
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
