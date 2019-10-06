using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Meteor : MonoBehaviour
{
   
    private float timeToDeath = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeToDeath += Time.deltaTime;
        if (timeToDeath > 10)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives -= 1;
            SceneManager.LoadScene("Dead");
            SoundManager.PlaySound("sizzle");
            SoundManager.PlaySound("die");
            Debug.Log("Player hurt");
            GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.red;
            StartCoroutine(ChangePlayerColor(1));
        }
    }
    IEnumerator ChangePlayerColor(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>().material.color = Color.white;
    }
}
