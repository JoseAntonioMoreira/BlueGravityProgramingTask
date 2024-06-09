using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    Inventory inventory;

    [SerializeField]
    private float moveSpeed = 5;

    private void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleAttack();
        HandleMovement();
        HandleInventory();
    }


    private void HandleAttack()
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


    private void HandleMovement()
    {
        Vector2 playerInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.velocity = playerInput * moveSpeed;

        HandleDirection(playerInput);

        anim.SetBool("isWalking", playerInput.sqrMagnitude > 0);
    }

    //Turns the character in the right direction
    private void HandleDirection(Vector2 playerInput)
    {
        if (playerInput.x < 0)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (playerInput.x > 0)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }
    }

    private void HandleInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.ToggleInventory();
        }
    }
}
