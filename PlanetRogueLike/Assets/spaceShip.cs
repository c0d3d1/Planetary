using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spaceShip : MonoBehaviour
{
    public TextMeshProUGUI Leave;
    public GameObject goToPlanet;
    public GameObject[] go;
    // Start is called before the first frame update
    void Start()
    {
        go = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < go.Length; i++)
        {
            if (go[i].name == "GoPlanet")
            {
                goToPlanet = go[i];
                
            }
            if (go[i].name == "Escape")
            {
                Leave = go[i].GetComponent<TextMeshProUGUI>();

            }
        }
    //    goToPlanet = GameObject.Find("GotoPlanet");
  //      Leave = GameObject.Find("Escape").GetComponent<TextMeshProUGUI>();
        Leave.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            Leave.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                SoundManager.PlaySound("select");
                goToPlanet.SetActive(true);
            //    Leave.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
        {
            Leave.gameObject.SetActive(false);
        }
    }
}
