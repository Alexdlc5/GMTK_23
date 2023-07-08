using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ambiance_manager : MonoBehaviour
{
    bool is_quiet = true;
    private void Start()
    {
        GetComponent<AudioSource>().volume = .30f;
    }
    // Update is called once per frame
    void Update()
    {
        AudioSource ambiance = GetComponent<AudioSource>();
        if (is_quiet && Input.GetKeyDown(KeyCode.Space))
        {
            ambiance.volume = 1f;
            is_quiet = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space)) 
        {
            ambiance.volume = .5f;
            is_quiet = true;
        }
    }
}
