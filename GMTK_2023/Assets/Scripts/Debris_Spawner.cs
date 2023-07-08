using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris_Spawner : MonoBehaviour
{
    public GameObject[] debris;
    public float time_till_debris = 9;
    public float boundry = 25;
    float timer = 0;

    // Update is called once per frame
    void Update()
    {
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
        int amount = Random.Range(1, 10);
        for (int i = 0; i < amount; i++)
        {
            //pick debris 
            int debris_index = Random.Range(0, debris.Length - 1);
            GameObject debris_type = debris[debris_index];
            //spawn
            Instantiate(debris_type, new Vector2(Random.Range(player_position.x + 50, player_position.x + 60), Random.Range(player_position.y - boundry, player_position.y + boundry)), transform.rotation);
        }
    }
}
