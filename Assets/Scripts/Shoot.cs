using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // ����� �������
            // Instantiate(���, ���, �������);
            // Quaternion.identity - ������� �������
            Instantiate(
                bullet,
                bulletSpawn.transform.position,
                bulletSpawn.transform.rotation
            );
        }
    }
}
