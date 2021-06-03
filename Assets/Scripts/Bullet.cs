using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public GameManager gameManager;
    public int damage = 10;
    private int totalDamage = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Asteroid")
        {
            GameManager.instance.points += damage;
            Destroy(collision.gameObject);
            
        }
    }
}
