using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlanetOptions : MonoBehaviour
{
    public GameObject[] PlanetTypes;
    public GameLasting gameLasting;
    // Start is called before the first frame update
    void Start()
    {
        gameLasting = GameObject.Find("GameManager").GetComponent<GameLasting>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0.00001f;
    }
    public void GiveUp()
    {
        Debug.Log("Give up");
        SceneManager.LoadScene("Dead");
    }
    public void NextPlanet()
    {
        if (gameLasting.fuel >= 3)
        {
            GameObject go = GameObject.FindGameObjectWithTag("Attracter");
            Destroy(go);
            int spawnIndex = Random.Range(0, PlanetTypes.Length);
            Instantiate(PlanetTypes[spawnIndex], Vector3.zero, Quaternion.identity);
            gameLasting.fuel -= 3;
            gameLasting.currentPlanet += 1;
        }
        else
        {
            Debug.Log("Out of fuel");
        }
        
    }
    public void GoToPlanet()
    {
        if (gameLasting.fuel >= 3)
        {
            gameLasting.fuel -= 3;
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Out of fuel");
        }
        
    }
}
