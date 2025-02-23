using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    public int value;
    public bool destroyOnUse = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��������� ���� �� � ������� ������� ��������

        // ����� ������� ��������
        HealthSystem hs;
        if(collision.gameObject.TryGetComponent(out hs))
        {
            hs.ChangeHealth(value);
            if (destroyOnUse == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
