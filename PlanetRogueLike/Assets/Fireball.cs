using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives -= 1;
            SoundManager.PlaySound("sizzle");
            Debug.Log("ded");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(ChangePlayerColor(1));
        }
    }
    IEnumerator ChangePlayerColor( float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.white;
    }
}
