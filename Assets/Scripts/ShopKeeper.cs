using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField]
    private GameObject inventory;
    [SerializeField]
    private GameObject shop;

    [SerializeField]
    private GameObject interactPrompt;

    void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if (interactPrompt.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            shop.SetActive(!shop.activeSelf);
            inventory.SetActive(shop.activeSelf);
        }
        else if (shop.activeSelf && !interactPrompt.activeSelf)
        {
            shop.SetActive(false);
            inventory.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactPrompt.SetActive(false);
        }
    }
}
