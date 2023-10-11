using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootBoost : MonoBehaviour
{
    public Transform[] shootingPoints; // Array to hold the shooting points
    public GameObject bulletPrefab;   // The bullet prefab to instantiate
    public float boostCooldownDuration = 5f; // Boost Cooldown duration in seconds
    public float bulletCD = 0.5f; // Bullet Cooldown duration in seconds
    public float timeAfterShooting = 0; // Time that passes after a shot
    private bool isMultiShotEnabled = false; // Indicates if multi-shot mode is active
    private float cooldownEndTime; // Time when cooldown ends

    void Update()
    {
        timeAfterShooting -= Time.deltaTime;
        // Check if multi-shot mode is active and cooldown has ended
        if (isMultiShotEnabled && Time.time >= cooldownEndTime)
        {
            isMultiShotEnabled = false; // Disable multi-shot 
        }
    }

    public void ShootBoostFunction(InputAction.CallbackContext shootBoost)
    {
        // Check for input to shoot
        if (shootBoost.performed && isMultiShotEnabled && timeAfterShooting <= 0.0)
        {
            // Fire from all shooting points
            foreach (Transform point in shootingPoints)
            {
                Instantiate(bulletPrefab, point.position, point.rotation);
            }
            timeAfterShooting = 0f;
        }
        else if(shootBoost.performed && !isMultiShotEnabled && timeAfterShooting <= 0.0)
        {
            // Fire from the first shooting point only
            Instantiate(bulletPrefab, shootingPoints[0].position, transform.rotation);
            timeAfterShooting = bulletCD;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shooting"))
        {
            isMultiShotEnabled = true;
            cooldownEndTime = Time.time + boostCooldownDuration;
        }
    }
}
