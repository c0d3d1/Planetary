using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutText;
    public TextMeshProUGUI tutText2;
    public TextMeshProUGUI tutText3;
    public TextMeshProUGUI tutText4;
    public GameObject Dasher; 
    // Start is called before the first frame update
    void Start()
    {
        tutText.text = "wasd to Move... I'd hope you would know that by now...";
        
    }
    IEnumerator Text2(float time)
    {
        yield return new WaitForSeconds(time);
        tutText.gameObject.SetActive(false);
        tutText2.gameObject.SetActive(true);
        tutText2.text = "Left click for sword attack. Right click for shield c'mon now it aint that hard. " +
            "Don't forget to hit the fuel. You just crashlanded and need stuff since you have nothing";
        StartCoroutine(Text3(4));
    }
    IEnumerator Text3(float time)
    {
        yield return new WaitForSeconds(time);
        tutText2.gameObject.SetActive(false);
        tutText3.gameObject.SetActive(true);
        tutText3.text = "Now use the skills I hope you have learned to fight this simple charger enemy(Dont forget to attack then hit the enemy, fuel canister, etc.)";
        Dasher.SetActive(true);
        StartCoroutine(Text4(10));
    }
    IEnumerator Text4(float time)
    {
        yield return new WaitForSeconds(time);
        tutText3.gameObject.SetActive(false);
        tutText4.gameObject.SetActive(true);
        tutText4.text = "Now go look for something that 'looks' like a spaceship(you will be able to tell with the large text that shows up) after picking up fuel";
        StartCoroutine(Text5(10));
    }
    IEnumerator Text5(float time)
    {
        yield return new WaitForSeconds(time);
        tutText4.gameObject.SetActive(false);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Text2(4));
    }
}
