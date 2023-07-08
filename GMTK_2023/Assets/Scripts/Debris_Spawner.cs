using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris_Spawner : MonoBehaviour
{
    public Plane plane;
    public float bird_speed_increase = 0;
    public int difficulty = 1;
    public GameObject[] debris;
    public float time_till_debris = .25f;
    public float boundry = 7;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        //difficulty scaling
        if (plane.score >= 5000 && difficulty < 2)
        {
            difficulty += 1;
            boundry -= 15;
            time_till_debris -= 2f;
            bird_speed_increase += 2;
        }
        else if (plane.score >= 10000 && difficulty < 3)
        {
            difficulty += 1;
            boundry -= 15;
            time_till_debris -= 2f;
            bird_speed_increase += 2;
        } 
        else if (plane.score >= 15000 && difficulty < 4)
        {
            difficulty += 1;
            boundry -= 10;
            time_till_debris -= 1f;
            bird_speed_increase += 2;
        }
        else if (plane.score >= 20000 && difficulty < 5)
        {
            difficulty += 1;
            boundry -= 10;
            time_till_debris -= 1f;
        }
        else if (plane.score >= 25000 && difficulty < 6) 
        {
            difficulty += 1;
            boundry -= 10;
            time_till_debris -= 1f;
            bird_speed_increase += 1;
        } 
        else if (plane.score >= 30000 && difficulty < 7)
        {
            difficulty += 1;
            bird_speed_increase += 1;
        }
        else if (plane.score >= 35000 && difficulty < 8)
        {
            difficulty += 1;
            bird_speed_increase += 1;
        }
        else if (plane.score >= 40000 && difficulty < 9)
        {
            difficulty += 1;
            bird_speed_increase += 1;
        }
        
        //debris spawn
        if (timer <= 0)
        {
            spawnDebris();
            timer = time_till_debris;
        }
        else 
        {
            timer -= Time.deltaTime;
        }
    }

    void spawnDebris()
    {
        Vector2 player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        int amount = Random.Range(40, 60);
        for (int i = 0; i < amount; i++)
        {
            //pick debris 
            int debris_index = Random.Range(0, debris.Length - 1);
            GameObject debris_type = debris[debris_index];
            //spawn
            Instantiate(debris_type, new Vector2(Random.Range(player_position.x + 50, player_position.x + 300), Random.Range(player_position.y - boundry, player_position.y + boundry)), transform.rotation).GetComponent<Debris>().speed += bird_speed_increase;
        }
    }
}
