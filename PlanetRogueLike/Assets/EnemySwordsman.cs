using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySwordsman : MonoBehaviour
{
  //  public float desiredDistance;
    public float walkSpeed = 3f;
    Vector3 moveDir;
    private Rigidbody rb;
    public Transform target;

    public Transform orb;
    public float radius;
    private Transform pivot;
    public bool notAttacking = true;
    private Renderer rr;
    public float chargeSpeed;
    Vector3 tempTarget;

    private SphereCollider sc;
    private bool canDash = false;
    // Start is called before the first frame update
    void Start()
    {
        
        rr = GetComponent<Renderer>();
        sc = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        pivot = orb.transform;
        transform.parent = pivot;
    }
    private void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Follow(target);
        if (notAttacking)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * walkSpeed * Time.deltaTime);
        }
        if (canDash)
        {
            Vector3 targetVector = tempTarget - transform.position;
            float speed = 5;
            Vector3 directionVector = targetVector.normalized * speed;
            directionVector = Quaternion.Inverse(transform.rotation) * directionVector;
            Vector3 dashDir = new Vector3(directionVector.x, directionVector.y, directionVector.z).normalized;
           // transform.position = Vector3.MoveTowards(transform.position, tempTarget, chargeSpeed * Time.deltaTime);
            rb.MovePosition(rb.position + transform.TransformDirection(dashDir) * chargeSpeed * Time.deltaTime);
            if (transform.position.x >= tempTarget.x - 0.03 && transform.position.x <= tempTarget.x + 0.03)
            {
                rr.material.color = Color.white;
                canDash = false;
                notAttacking = true;
               
            }
        }

   //     AimTowards();
    }
    
    public void Follow(Transform target)
    {
        // get direction to target
        Vector3 targetVector = target.position - transform.position;
        float speed = 5;
        Vector3 directionVector = targetVector.normalized * speed;
        
        directionVector = Quaternion.Inverse(transform.rotation) * directionVector;
        moveDir = new Vector3(directionVector.x, directionVector.y, directionVector.z).normalized;
    }
    /* void AimTowards()
     {
         float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;

         pivot.localRotation = Quaternion.AngleAxis(angle - 90, Vector3.down);
     }*/
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            notAttacking = false;
            tempTarget = target.position;
            StartCoroutine(Dash(1.5f));
        }
    }
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.CompareTag("Player")&& !obj.gameObject.GetComponent<CapsuleCollider>().isTrigger)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives -= 1;
            SoundManager.PlaySound("die");
            Debug.Log("Player dead");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(ChangePlayerColor(2));
        }
    }
    IEnumerator Dash(float time)
    {
        rr.material.color = Color.red;
        yield return new WaitForSeconds(time);
        canDash = true;
    }
    IEnumerator ChangePlayerColor(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.white;
    }
}
