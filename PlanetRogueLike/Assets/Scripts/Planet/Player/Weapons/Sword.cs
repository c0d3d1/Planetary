using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float timeBtwAttacks = 5;
    private float actualTimeBtwAttacks = 0;
    public bool canAttack = true;

    public Transform orb;
    public float radius;
    private Transform pivot;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pivot = orb.transform;
        transform.parent = pivot;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        AimTowards();
    }
    public void Attack()
    {
        actualTimeBtwAttacks += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && timeBtwAttacks < actualTimeBtwAttacks && canAttack)
        {
            
            StartCoroutine(AttackAnim(0.8f));
            actualTimeBtwAttacks = 0;
        }
    }
    void AimTowards()
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
        orbVector = Input.mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;

        pivot.localRotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
    }
    private IEnumerator AttackAnim(float time)
    {
        anim.SetBool("isAttacking", true);
        Debug.Log("Attacking");
        yield return new WaitForSeconds(time);
        Debug.Log("not Attacking");
        anim.SetBool("isAttacking", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (anim.GetBool("isAttacking") && !other.isTrigger)
        {
            if (other.CompareTag("Fuel"))
            {
                SoundManager.PlaySound("hit");
                GameLasting gl = GameObject.Find("GameManager").GetComponent<GameLasting>();
                gl.fuel += 1;
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Dasher"))
            {
                SoundManager.PlaySound("sizzle");
                SoundManager.PlaySound("die");
                Destroy(other.gameObject);
                GameLasting gl = GameObject.Find("GameManager").GetComponent<GameLasting>();
                gl.fuel += 1;
            }
            if (other.CompareTag("Boss"))
            {
                SoundManager.PlaySound("sizzle");
                SoundManager.PlaySound("die");
                Boss bs = GameObject.Find("Boss").GetComponent<Boss>();
                bs.lives--;
                bs.GetComponent<Renderer>().material.color = Color.red;
                StartCoroutine(ChangeColor(1));
                GameLasting gl = GameObject.Find("GameManager").GetComponent<GameLasting>();
                gl.fuel += 1;
            }
        }
    }
    private IEnumerator ChangeColor(float time)
    {
        yield return new WaitForSeconds(time);
        Boss bs = GameObject.Find("Boss").GetComponent<Boss>();
        bs.GetComponent<Renderer>().material.color = Color.cyan;
    }
}

