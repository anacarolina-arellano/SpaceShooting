using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.1f;
    public GameObject bullets;
    float m_fSpeed = 100.0f;
    bool canMoveLeft = true;
    bool canMoveRight = true;

    private float shootTime = 0.0f;


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
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(canMoveRight)
            {
                transform.Translate(Vector3.right * Time.deltaTime * m_fSpeed, Space.World);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (canMoveLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * m_fSpeed, Space.World);
            }
        }


    }

    void Fire()
    { 
        GameObject bullet = Instantiate(bullets, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        Destroy(bullet, 3);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("RightWall"))
        {
            canMoveRight = false;
        }
        if (collision.collider.CompareTag("LeftWall"))
        {
            canMoveLeft = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("RightWall"))
        {
            canMoveRight = true;
        }
        if (collision.collider.CompareTag("LeftWall"))
        {
            canMoveLeft = true;
        }
    }

}
