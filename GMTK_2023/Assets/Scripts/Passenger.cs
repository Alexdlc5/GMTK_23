using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public Passenger_Manager manager;
    public Plane plane;
    public bool needs_help = false;
    public SpriteRenderer sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (needs_help && !plane.is_pilot)
        {
            sprite.color = new Color(1, 1, 1, 1);
        }
        else
        {
            sprite.color = new Color(1, 1, 1, 0);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Crew" && needs_help == true)
        {
            GetComponent<AudioSource>().Play();
            needs_help = false;
            manager.objective_given = false;
            sprite.color = new Color(1, 1, 1, 0);
            plane.score += 500;
        }
    }
}
