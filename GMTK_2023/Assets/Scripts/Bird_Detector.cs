using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Detector : MonoBehaviour
{
    public AudioSource alarm;
    public float timer = 0;
    public bool playing = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!playing && collision.gameObject.tag == "Debris")
        {
            //maybe change to visual alarm
            alarm.Play();
            playing = true;
        }
    }
    private void Update()
    {
        //                          ||
        //    change whole num only \/       
        float num_of_beeps = .361f * 5;
        if (playing && timer < num_of_beeps)
        {
            timer += Time.deltaTime;
        }
        else if (playing && timer >= num_of_beeps)
        {
            timer = 0;
            alarm.Stop();
            playing = false;
        }
    }
}
