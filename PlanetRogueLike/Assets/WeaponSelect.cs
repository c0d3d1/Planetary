using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public GameObject Sword;
    public GameObject Bow;
    public GameObject Shield;
    void Update()
    {
        Select();
    }
    private void Select()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Sword.SetActive(true);
            Shield.SetActive(true);
            Bow.SetActive(false);
        }
     /*   if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Sword.SetActive(false);
            Shield.SetActive(false);
            Bow.SetActive(true);
        }*/
    }
}
