using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float pickupDelay = 1F;
    bool hasPackage = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ow");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(collision.gameObject, pickupDelay);
        }

        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered to customer");
            hasPackage = false;
        }

    }
}
