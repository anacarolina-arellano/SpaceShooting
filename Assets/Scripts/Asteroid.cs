using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    float m_Speed = 5f;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = -transform.up * m_Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This is how I wanat to destroy the asteroids, the bullets are triggers
        //For some reason is not working
        Destroy(this);
    }
}
