using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float pickupDelay = 1F;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ow");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Destroy(collision.gameObject, pickupDelay);
        }

        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered to customer");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }

    }
}
