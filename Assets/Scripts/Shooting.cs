using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float bulletCD = 0.5f;
    public bool shooting;
    public float timeAfterShooting = 0;

    private void Start()
    {
        shooting = false;
    }

    private void Update()
    {
        timeAfterShooting -= Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext shoot)
    {
        if(shoot.performed && timeAfterShooting <= 0.0f)
        {
            timeAfterShooting = bulletCD;
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}
