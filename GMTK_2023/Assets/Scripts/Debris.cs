using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public float x_boundry = -40;
    public float speed = 8;
    public bool is_cloud = false;
    private void Start()
    {
        if (is_cloud)
        {
            int random = Random.Range(-50,50);
            if (random > 0)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 25;
            }
            else
            {
                GetComponent<SpriteRenderer>().sortingOrder = -25;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        if (transform.position.x <= player_position.x + x_boundry)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        } 
    }
}
