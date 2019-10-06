using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    private FauxGravityAttractor attracter;
    private Transform myTransform;
    private Rigidbody rb;
    private bool canAttract = false;

    private void Start()
    {
        
        StartCoroutine(Gravity(0.1f));
    }
    IEnumerator Gravity(float time)
    {
        yield return new WaitForSeconds(time);
        attracter = GameObject.FindGameObjectWithTag("Attracter").GetComponent<FauxGravityAttractor>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        myTransform = transform;
        canAttract = true;
    }
    private void Update()
    {
        if (canAttract)
        {
            attracter.Attract(myTransform);
        }
        
    }
}
