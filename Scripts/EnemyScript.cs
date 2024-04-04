using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator animator;

    private int Health = 100;

    private bool canMove = true;

    private Rigidbody rb;
    public float speed = 2f;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        animator.Play("Walk");
        Debug.Log("Walk Called");
    }

    private void FixedUpdate()
    {
       transform.LookAt(player.transform);
       if(canMove)
       {
            Vector3 newPosition = rb.position + transform.forward * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
       }
    }

    public void OnHit()
    {
        if (Health > 0)
        {
            Health -= 25;
            animator.Play("Get_hit");
            if (Health <= 0)
            {
                canMove = false;
                animator.Play("Dead");
                Destroy(GetComponent<CapsuleCollider>());
                Destroy(gameObject, 2f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("End Game");
        }
    }
}
