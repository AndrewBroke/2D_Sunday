using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Уничтожение объекта
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }


    // collision - переменная с информацией о том,
    // с кем столкнулся объект
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
