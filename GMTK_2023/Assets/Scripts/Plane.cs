using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;

public class Plane : MonoBehaviour
{
    public AudioSource hit;
    public float time = 0;
    public TextMeshProUGUI time_display;
    public TextMeshProUGUI highscore_display;
    public TextMeshProUGUI score_display;
    public float score = 0;
    public bool game_over = false;
    public int plane_health = 3;
    public GameObject plane_inside;
    public GameObject crew;
    public GameObject alarm;
    public GameObject plane_outside;
    public Sprite damaged_plane;
    public Sprite very_damaged_plane;
    public bool is_pilot = true;
    private CinemachineVirtualCamera camera_settings;
    private void Start()
    {
        highscore_display.text = "Highscore: " + (int)Stats.highscore + " (" + (int)Stats.HStime + "sec)";
        camera_settings = GameObject.FindAnyObjectByType<CinemachineVirtualCamera>();
    }
    // Update is called once per frame
    void Update()
    {
        score_display.text = "Score: " + (int)score;
        if (plane_health <= 0)
        {
            game_over = true;
            Stats.previous_score = score;
            if (Stats.highscore < score)
            {
                Stats.highscore = score;
                Stats.HStime = time;
            }
            SceneManager.LoadScene(2);
        }
        else
        {
            time += Time.deltaTime;
            time_display.text = "Time: " + (int)time + "sec";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_pilot = !is_pilot;
        }
        if (is_pilot)
        {
            camera_settings.m_Lens.OrthographicSize = 15;
            camera_settings.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(13.5f,-0.77f,0f);
            camera_settings.Follow = gameObject.transform;
            plane_outside.GetComponent<SpriteRenderer>().sortingOrder = 1;
            plane_inside.GetComponent<SpriteRenderer>().sortingOrder = 0;
            crew.GetComponent<SpriteRenderer>().sortingOrder = 0;
            alarm.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            camera_settings.m_Lens.OrthographicSize = 7.83f;
            camera_settings.GetComponentInChildren<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector3(2.67f, -0.5f, 0f);
            plane_outside.GetComponent<SpriteRenderer>().sortingOrder = 0;
            plane_inside.GetComponent<SpriteRenderer>().sortingOrder = 1;
            crew.GetComponent<SpriteRenderer>().sortingOrder = 2;
            alarm.GetComponent<SpriteRenderer>().sortingOrder = 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Debris") 
        {
            hit.Play();
            plane_health -= 1;
            Destroy(collision.gameObject);
            if (plane_health == 2)
            {
                plane_outside.GetComponent<SpriteRenderer>().sprite = damaged_plane;
            }
            else if (plane_health == 1) 
            {
                plane_outside.GetComponent<SpriteRenderer>().sprite = very_damaged_plane;
            }
        }
    }
}
