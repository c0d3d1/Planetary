using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameLasting : MonoBehaviour
{
    public int fuel = 0;
    public int currentPlanet = 0;
    public TextMeshProUGUI planetAmount;
    public TextMeshProUGUI FuelAmount;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        FuelAmount.text = fuel.ToString();
        if (planetAmount == null)
        {
            planetAmount = GameObject.Find("planetAmount").GetComponent<TextMeshProUGUI>();
        }
        else
        {
            planetAmount.text = currentPlanet.ToString();
        }
        
    }
}
