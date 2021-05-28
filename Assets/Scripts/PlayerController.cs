using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.1f;
    public GameObject bullets;
    float m_fSpeed = 5.0f;

    private float shootTime = 0.0f;


    void Start()
    {

    }



    void FixedUpdate()
    {
        shootTime += Time.deltaTime;
        Move();
        if (Input.GetKey(KeyCode.Space) && shootTime >= cooldown) { 
            Fire();
            shootTime = 0;
        }
    }
    void Move()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * m_fSpeed * fHorizontal, Space.World);
        transform.Translate(Vector3.up * Time.deltaTime * m_fSpeed * fVertical, Space.World);
    }

 
    void Fire()
    { 
        GameObject bullet = Instantiate(bullets, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);        
    }
}
