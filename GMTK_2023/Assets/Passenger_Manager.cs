using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_Manager : MonoBehaviour
{
    public GameObject[] people;
    public bool objective_given = false;
    private void Start()
    {
        people = GameObject.FindGameObjectsWithTag("Person");
    }
    private void Update()
    { 
        if (!objective_given)
        {
            int random_index = Random.Range(0, 11);
            people[random_index].GetComponent<Passenger>().needs_help = true;
            objective_given = true;
        }
    }
}
