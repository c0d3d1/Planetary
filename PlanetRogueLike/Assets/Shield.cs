using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private BoxCollider bc;
    public Sword sword;

    public Transform orb;
    public float radius;
    private Transform pivot;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider>();
        pivot = orb.transform;
        transform.parent = pivot;
        StartCoroutine(Gravity(0.2f));
    }
    IEnumerator Gravity(float time)
    {
        yield return new WaitForSeconds(time);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        AimTowards();

        if (Input.GetMouseButton(1))
        {
            sword.canAttack = false;
            bc.isTrigger = false;
            player.GetComponent<CapsuleCollider>().isTrigger = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            player.GetComponent<CapsuleCollider>().isTrigger = false;
            sword.canAttack = true;
            bc.isTrigger = true;
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
    void AimTowards()
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.localRotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
    }
}
