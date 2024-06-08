using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float defaultMoveSpeed = 5;
    private float currentMoveSpeed;


    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Attack();
        Move();
    }

    //Attack function
    private void Attack()
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
    private void Move()
    {
        Vector2 playerInput;
        playerInput.x = Input.GetAxisRaw("Horizontal");
        playerInput.y = Input.GetAxisRaw("Vertical");

        rb.velocity = playerInput * currentMoveSpeed;

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
        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }
}
