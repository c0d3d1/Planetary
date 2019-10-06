using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip die, hit, select, sizzle;
    static AudioSource audiosrc;
    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("hit");
        die = Resources.Load<AudioClip>("die");
        select = Resources.Load<AudioClip>("select");
        sizzle = Resources.Load<AudioClip>("sizzle");

        audiosrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "hit":
                audiosrc.PlayOneShot(hit);
                break;
            case "die":
                audiosrc.PlayOneShot(die);
                break;
           case "select":
                audiosrc.PlayOneShot(select);
                break;
            case "sizzle":
                audiosrc.PlayOneShot(sizzle);
                break;
        }

    }
}
