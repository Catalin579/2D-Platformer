using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  ( collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
