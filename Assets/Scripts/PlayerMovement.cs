using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    // ��������� ����������
    public float speed = 1;
    public Vector3 boxOffset;
    public Vector3 boxSize;
    public LayerMask mask;

    // ���� ��������
    public float jetpackForce = 2;
    // Start is called before the first frame update
    void Start()
    {
        print("������� Start");
        // �������� ��������� Rigidbody 2D
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
        // ������� ��������
        // ��������� �������� ������ �������� �� �����������
        float horizontal = Input.GetAxis("Horizontal"); // [-1, 1]

        print(horizontal);

        // ������� ������ ��������
        // ��������� ������ �������� �� Y
        float oldSpeedY = rb.velocity.y;
        Vector2 move = new Vector2(horizontal * speed, oldSpeedY);

        // ��������� ������ ��������
        rb.velocity = move;

        Rotate(horizontal);
    }

    void Rotate(float dir)
    {
        // ������� scale
        Vector2 s = transform.localScale;
        if(dir < 0)
        {
            // ������� ����� -> -x
            if(s.x > 0)
            {
                s.x = -s.x;
            }
        }
        else if (dir > 0)
        {
            // ������� ������
            if(s.x < 0)
            {
                s.x = -s.x;
            }
        }
        // ������� �����
        transform.localScale = s;
    }

    void SetAnimations()
    {
        float currentSpeed = Mathf.Abs(rb.velocity.x);
        // ������ �������� float
        animator.SetFloat("Speed", currentSpeed);
        animator.SetBool("Grounded", Grounded());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        SetAnimations();
        
    }

    // ����������� 50 ��� � ������� (�� ���������)
    void FixedUpdate()
    {
        // ����������� ������ ����, ���� ���
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
        // �������� �������
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            transform.position + boxOffset,
            boxSize
        );
    }
}
