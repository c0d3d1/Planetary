using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private States state;

    public GameObject pfMeteor;
    private float stateTimer = 0;
    public Transform[] meteorSpawnPoints;
    public Transform[] chargerSpawnPoints;
    private float meteorTimer = 0;
    public GameObject[] fireballs;
    public float fireballSpeed = 3;
    public List<GameObject> fireball = new List<GameObject>();
    public GameObject pfCharger;
    private bool canInstantate = true;
    public int lives = 3;
    public GameObject pfParticles;
    public enum States
    {
        None,
        Meteor,
        Disperse,
        Chargers
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.cyan;
        state = States.None;
        StartCoroutine(StartWorldTime(5));
    }
    IEnumerator StartWorldTime(float time)
    {
        yield return new WaitForSeconds(time);
        state = States.Meteor;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(lives);
        if (lives <= 0)
        {
            Instantiate(pfParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (state == States.Meteor)
        {
            Meteor();
        }
        if (state == States.Disperse)
        {
            Disperse();
        }
        if (state == States.Chargers)
        {
            Chargers();
        }
    }
    void SpawnEnemies()
    {
        int spawnIndex = Random.Range(0, meteorSpawnPoints.Length);
        GameObject test = Instantiate(pfMeteor, meteorSpawnPoints[spawnIndex].position, meteorSpawnPoints[spawnIndex].rotation);
        test.transform.SetParent(GameObject.FindGameObjectWithTag("Attracter").transform);
    }
    private void Meteor()
    {
        stateTimer += Time.deltaTime;
        meteorTimer += Time.deltaTime;
        if (meteorTimer > 0.2f)
        {
            SpawnEnemies();
            meteorTimer = 0;
        }
        if (stateTimer > 15)
        {
            state = States.Disperse;
            stateTimer = 0;
        }

    }
    private void Disperse()
    {
        stateTimer += Time.deltaTime;

        if (stateTimer > 15)
        {
            state = States.Chargers;
            stateTimer = 0;
        }
        for (int i = 0; i < fireballs.Length; i++)
        {
                fireball.Add(fireballs[i]);
                fireball[i].GetComponent<Rigidbody>().isKinematic = false;
            
            
        }

        StartCoroutine(FireballLifetime(15));
    }
    IEnumerator FireballLifetime(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < fireball.Count; i++)
        {
            Destroy(fireball[i]);
        }
    }
    private void Chargers()
    {
        stateTimer += Time.deltaTime;
        if (stateTimer > 25)
        {
            state = States.Meteor;
            stateTimer = 0;
        }
        if (canInstantate)
        {
            for (int i = 0; i < chargerSpawnPoints.Length; i++)
            {
                Instantiate(pfCharger, chargerSpawnPoints[i].position, Quaternion.identity);
            }
            canInstantate = false;
        }
        

    }
}
