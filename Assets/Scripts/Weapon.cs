using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public float fireRate = 0.5f;
    private float nextFire = 0f;

    public void Fire(){

        if(Time.time > nextFire){
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 

            rb.AddForce(firePoint.up * fireForce , ForceMode2D.Impulse);
        }

    }
}
