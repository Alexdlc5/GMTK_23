using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Detector : MonoBehaviour
{
    public Plane plane;
    public Animator lighting;
    public AudioSource alarm;
    public float timer = 0;
    public bool playing = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!playing && !plane.is_pilot && collision.gameObject.tag == "Debris")
        {
            lighting.SetBool("Alarm", true);
            alarm.Play();
            playing = true;
        }
    }
    private void Update()
    {
        //                          ||
        //    change whole num only \/       
        float num_of_beeps = .361f * 3;
        if (playing && timer < num_of_beeps)
        {
            timer += Time.deltaTime;
        }
        else if (playing && timer >= num_of_beeps)
        {
            timer = 0;
            lighting.SetBool("Alarm", false);
            alarm.Stop();
            playing = false;
        }
        if (plane.is_pilot)
        {
            alarm.Stop();
            lighting.SetBool("Alarm", false);
        }
    }
}
