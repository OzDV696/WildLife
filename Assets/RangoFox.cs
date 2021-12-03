using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoFox : MonoBehaviour
{
    public Animator animator;
    public Fox fox;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Perro"))
        {
            animator.SetBool("walk", false);
            animator.SetBool("attack", true);
            fox.attacking = true;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
