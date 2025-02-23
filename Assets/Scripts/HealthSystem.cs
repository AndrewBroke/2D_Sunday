using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class HealthSystem : MonoBehaviour
{
    // Из чего состоит
    // 1. Отображение здоровья в виде количества
    // 2. Изменение здоровья
    // 3. Действия при смерти

    // Ссылка на текст в UI
    public TextMeshProUGUI healthText;
    int health;

    // Список событий
    public UnityEvent onDead;

    public void ChangeHealth(int value)
    {
        health = health + value;
        if(health <= 0)
        {
            health = 0;
            // Запустить события
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
        // Вывод на интерфейс
        health = 100;
        healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
