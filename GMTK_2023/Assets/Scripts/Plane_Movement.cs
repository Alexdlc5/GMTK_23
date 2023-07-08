using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane_Movement : MonoBehaviour
{
    private Plane plane;
    public float speed = 10;
    private void Start()
    {
        plane = GameObject.FindAnyObjectByType<Plane>();
    }
    // Update is called once per frame
    void Update()
    {
        if (plane.is_pilot)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            }
        }
    }
}
