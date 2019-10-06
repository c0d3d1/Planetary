using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Transform orb;
    public float radius;
    public float projectileSpeed = 2;
    private Transform pivot;

    public float timeBtwShots = 3;
    private float actualTimeBtwShots = 0;

    public GameObject pfProjectile;
    public GameObject muzzle;

    void Start()
    {
        pivot = orb.transform;
        transform.parent = pivot;
    }

    void Update()
    {
        AimTowards();
        Shoot();
    }
    void AimTowards()
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.localRotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
    }
    void Shoot()
    {
        actualTimeBtwShots += Time.deltaTime;

        if (timeBtwShots < actualTimeBtwShots && Input.GetMouseButtonDown(0))
        {
            //  Vector3 sp = Camera.main.WorldToScreenPoint(muzzle.transform.position);
            //  Vector3 dir = (Input.mousePosition - sp).normalized;
            //  GameObject bullet = Instantiate(pfProjectile, muzzle.transform.position, Quaternion.identity);       

            //  bullet.GetComponent<Rigidbody>().MovePosition(bullet.GetComponent<Rigidbody>().position 
            //      + muzzle.transform.TransformDirection(dir) * projectileSpeed * Time.deltaTime * 1000);
            //  actualTimeBtwShots = 0;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = (mousePosition - transform.position).normalized;
            GameObject bullet = Instantiate(pfProjectile, transform.position, Quaternion.identity);
            bullet.transform.position += direction * projectileSpeed * Time.deltaTime;
            //  bullet.GetComponent<Rigidbody>().MovePosition(bullet.GetComponent<Rigidbody>().position
            //        + transform.TransformDirection(dir) * projectileSpeed * Time.deltaTime * 1000);
            actualTimeBtwShots = 0;
        }
    }
}
