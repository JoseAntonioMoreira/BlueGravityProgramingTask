using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject shop;

    [SerializeField]
    private GameObject interactPrompt;

    private bool isPlayerInRange = false;

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shop.SetActive(!shop.activeSelf);
        }
        else if (!isPlayerInRange)
        {
            shop.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactPrompt.SetActive(false);
        }
    }
}
