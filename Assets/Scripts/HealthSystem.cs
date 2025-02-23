using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    // �� ���� �������
    // 1. ����������� �������� � ���� ����������
    // 2. ��������� ��������
    // 3. �������� ��� ������

    // ������ �� ����� � UI
    public TextMeshProUGUI healthText;
    int health;

    // ������ �������
    public UnityEvent onDead;

    public void ChangeHealth(int value)
    {
        health = health + value;
        if(health <= 0)
        {
            health = 0;
            // ��������� �������
            onDead.Invoke();
        }
        if(health > 100)
        {
            health = 100;
        }
        healthText.text = health.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // ����� �� ���������
        health = 100;
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
