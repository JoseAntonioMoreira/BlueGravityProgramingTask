using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed = 5;


    // Use this for initialization
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        Move();
    }

    //Attack function
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Attack2");
        }
    }


    // character Move Function
    void Move()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        rb.velocity = playerInput * moveSpeed;

        //turn player in correct direction
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

        //Animation condition
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }
}
