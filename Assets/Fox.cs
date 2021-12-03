using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public Animator animation;
    public int maxHealth = 100;
    int currentHealth;
    public int routine;
    public float timer;
    public int directions;
    public float speed_walk;
    public float speed_run;
    public GameObject target;
    public bool attacking;
    public float range_vision;
    public float range_attack;
    public GameObject rango;
    public int dogdamage = 10;
    public Score score;



    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        target = GameObject.Find("Perro1");
        currentHealth = maxHealth;
    }

    public void Behavior()
    {
        if (Mathf.Abs(transform.position.x - target.transform.position.x) > range_vision)
        {
        animation.SetBool("run", false);
        timer += 1 * Time.deltaTime;
        if (timer >= 3)
        {
            routine = Random.Range(0, 2);
            timer = 0;

        }

        switch (routine)
        {
            case 0:
                animation.SetBool("walk", false);
                break;
            case 1:
                directions = Random.Range(0, 2);
                routine++;
                break;
            case 2:
                switch (directions)
                {
                    case 0:
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                    case 1:
                        transform.rotation = Quaternion.Euler(0, 180, 0);
                        transform.Translate(Vector3.right * speed_walk * Time.deltaTime);
                        break;
                }
                animation.SetBool("walk", true);
                break;
        }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - target.transform.position.x) > range_attack )
            {
                if (transform.position.x < target.transform.position.x)
                {
                    animation.SetBool("walk", false);
                    animation.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    animation.SetBool("attack", false);
                }
                else
                {
                    animation.SetBool("walk", false);
                    animation.SetBool("run", true);
                    transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    animation.SetBool("attack", false);
                }
            }
        }
    }

   
    void Update()
    {
        Behavior();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if(currentHealth <= 0)
        {
            Die();
            Score.instance.AumentarScore(20);
        }

    }


    void Die()
    {
        //Debug.Log("Enemy died!");
        //GetComponent<Collider2D>().enabled = false;
        //this.enabled = false;
        Destroy(gameObject);
    }
}
