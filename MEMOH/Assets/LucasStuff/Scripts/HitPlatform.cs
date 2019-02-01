using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlatform : MonoBehaviour
{
    public Sprite iconToLoad;
    public GameObject noyau;
    Rigidbody2D myRb;
    public bool gravityPlatform;
    public bool hitted = false;

    private void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ChangeIcon();
            hitted = true;

            if (gravityPlatform)
            {
                myRb.gravityScale = 1;
            }
        }
    }

    void ChangeIcon()
    {
        noyau.GetComponent<SpriteRenderer>().sprite = iconToLoad;
    }
}