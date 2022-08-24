using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class patrol : MonoBehaviour
{
    public Transform groundpos;
    public float speed;
    public float rad;
    public LayerMask groundlayer;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void Patrol()
    {
        rb.velocity = new Vector2(speed, 0f);
        bool isGrounded = Physics2D.OverlapCircle(groundpos.position, rad, groundlayer);

        if (!isGrounded)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            speed *= -1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision )
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
