using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Plane : MonoBehaviour
{
    public bool game_over = false;
    public int plane_health = 3;
    public GameObject plane_inside;
    public GameObject crew;
    public GameObject plane_outside;
    public bool is_pilot = true;
    private CinemachineVirtualCamera camera_settings;
    private void Start()
    {
        camera_settings = GameObject.FindAnyObjectByType<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (plane_health <= 0)
        {
            game_over = true;
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_pilot = !is_pilot;
        }
        if (is_pilot)
        { 
            camera_settings.m_Lens.OrthographicSize = 20;
            camera_settings.Follow = gameObject.transform;
            plane_outside.GetComponent<SpriteRenderer>().sortingOrder = 1;
            plane_inside.GetComponent<SpriteRenderer>().sortingOrder = 0;
            crew.GetComponent<SpriteRenderer>().sortingOrder = 0;

        }
        else
        {
            camera_settings.m_Lens.OrthographicSize = 4.37f;
            //camera_settings.Follow = crewmember;
            plane_outside.GetComponent<SpriteRenderer>().sortingOrder = 0;
            plane_inside.GetComponent<SpriteRenderer>().sortingOrder = 1;
            crew.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Debris") 
        {
            plane_health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
