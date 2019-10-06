using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 15;
    private Vector3 moveDir;
    private Rigidbody rb;
    public int lives = 3;
   
    private void Start()
    {
      //  SceneManager.LoadScene("Dead");
        rb = GetComponent<Rigidbody>();
        transform.position = GameObject.FindGameObjectWithTag("spawnPoint").transform.position;
    }
    void Update()
    {
        if (lives<= 0)
        {
            SceneManager.LoadScene("Dead");
        }
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);

    }
    
}

