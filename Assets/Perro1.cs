using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Perro1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 400;
    int currentHealth;
    public float Speed;
    public float JumpForce;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.35f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal") * Speed;
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.2053686f, 0.2581665f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.2053686f, 0.2581665f, 1.0f);
        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 0.75f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.75f))
        {
            Grounded = true;
            Animator.SetBool("Grounded", Grounded);
        }
        else Grounded = false;
        Animator.SetBool("Grounded", Grounded);

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
    void Attack()
    {
        Animator.SetTrigger("Attack");
        Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in HitEnemies)
        {
            enemy.GetComponent<Fox>().TakeDamage(attackDamage);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            maxHealth -= collision.GetComponent<Fox>().dogdamage;

            if (maxHealth <= 0)
            {
                //Time.timeScale = 0;
                //GameOverImg.SetActive(true);
                Debug.Log("Juego termino");
                Die();

            }
        }
    }


    void Die()
    {
        //Debug.Log("Enemy died!");
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        FindObjectOfType<Game>().EndGame();
        Destroy(gameObject);
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
