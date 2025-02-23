using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed * 
            GetSign(transform.localScale.x);
    }


    float GetSign(float a)
    {
        if(a > 0)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyEdge")
        {
            // Взять scale
            Vector3 s = transform.localScale;

            // Изменить его
            s.x = -s.x;

            // Вернуть scale
            transform.localScale = s;
        }
    }
}
