using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    Inventory inventory;

    [SerializeField]
    private float defaultMoveSpeed = 5;
    private float currentMoveSpeed;

    private void Start()
    {
        currentMoveSpeed = defaultMoveSpeed;
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleAttack();
        HandleMovement();
        HandleInventory();
    }

    // Attack function
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

    // Character Move function
    private void HandleMovement()
    {
        Vector2 playerInput = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        rb.velocity = playerInput * currentMoveSpeed;

        HandleDirection(playerInput);

        // Animation condition
        anim.SetBool("isWalking", playerInput.sqrMagnitude > 0);
    }

    // Handle player direction
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
