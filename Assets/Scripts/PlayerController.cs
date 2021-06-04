using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.1f;
    public GameObject bullets;
    float m_fSpeed = 5.0f;
    public GameManager gameManager;
    //can go to that direction
    public bool isRight;
    public bool isLeft;

    private float shootTime = 0.0f;

    private void Start()
    {
        isRight = true;
        isLeft = true;
    }
    void FixedUpdate()
    {
        shootTime += Time.deltaTime;
        Move();
        if (Input.GetKey(KeyCode.Space)) {
            Fire();
        }
    }
    void Move()
    {
         float fHorizontal = Input.GetAxis("Horizontal");
         if ((fHorizontal > 0 && isRight) || (fHorizontal < 0 && isLeft))
         {
            transform.Translate(Vector3.right * Time.deltaTime * m_fSpeed * fHorizontal, Space.World);
         }
    }


    void Fire()
    { 
        GameObject bullet = Instantiate(bullets, transform.position, transform.rotation);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        Destroy(bullet, 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Asteroid")
        {
            GameManager.instance.health -= 0.34f;

            if (GameManager.instance.health <= 0.0f)
            {
                gameManager.gameOver = true;
            }
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.name == "RightWall")
        {
            isRight = false;
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            isLeft = false;
        }

        if (collision.gameObject.tag == "PowerUp")
        {
            GameManager.instance.health += 0.34f;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "RightWall")
        {
            isRight = true;
        }
        else if (collision.gameObject.name == "LeftWall")
        {
            isLeft = true;
        }
    }
}
