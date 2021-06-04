using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 2;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
        rigid.velocity = Vector2.down * speed;
    }
}
