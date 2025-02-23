using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    // Публичная переменная
    public float speed = 1;
    public Vector3 boxOffset;
    public Vector3 boxSize;
    public LayerMask mask;

    // Сила Джетпака
    public float jetpackForce = 2;
    // Start is called before the first frame update
    void Start()
    {
        print("Функция Start");
        // Получить компонент Rigidbody 2D
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Fly()
    {
        Vector2 flyDir = new Vector2(0, 1);
        rb.AddForce(flyDir * jetpackForce);
    }

    void Move()
    {
        // Считать движение
        // Получение значения клавиш движения по горизонтали
        float horizontal = Input.GetAxis("Horizontal"); // [-1, 1]

        print(horizontal);

        // Создать вектор движения
        // Запомнить старую скорость по Y
        float oldSpeedY = rb.velocity.y;
        Vector2 move = new Vector2(horizontal * speed, oldSpeedY);

        // Присвоить вектор движения
        rb.velocity = move;

        Rotate(horizontal);
    }

    void Rotate(float dir)
    {
        // Достаем scale
        Vector2 s = transform.localScale;
        if(dir < 0)
        {
            // Поворот влево -> -x
            if(s.x > 0)
            {
                s.x = -s.x;
            }
        }
        else if (dir > 0)
        {
            // Поворот вправо
            if(s.x < 0)
            {
                s.x = -s.x;
            }
        }
        // Обратно кладём
        transform.localScale = s;
    }

    void SetAnimations()
    {
        float currentSpeed = Mathf.Abs(rb.velocity.x);
        // Задать параметр float
        animator.SetFloat("Speed", currentSpeed);
        animator.SetBool("Grounded", Grounded());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetAnimations();
        
    }

    // Запускается 50 раз в секунда (по умолчанию)
    void FixedUpdate()
    {
        // Срабатывает каждый кадр, пока жмём
        if (Input.GetKey(KeyCode.Space))
        {
            Fly();
        }
    }

    bool Grounded()
    {
        Collider2D col = Physics2D.OverlapBox(
            transform.position + boxOffset, 
            boxSize,
            0,
            mask);
        print(col);
        return col != null;
    }

    private void OnDrawGizmos()
    {
        // Рисовать квадрат
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            transform.position + boxOffset,
            boxSize
        );
    }
}
