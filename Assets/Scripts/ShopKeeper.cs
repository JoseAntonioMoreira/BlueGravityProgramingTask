using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;

    private bool isPlayerInRange = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shop.SetActive(!shop.gameObject.activeSelf);
        }
        else if (!isPlayerInRange)
        {
            shop.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPlayerInRange = false;
        }
    }
}
