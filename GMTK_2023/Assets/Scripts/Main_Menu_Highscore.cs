using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Main_Menu_Highscore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Highscore: " + (int)Stats.highscore + " (" + (int)Stats.HStime + "sec)";
    }
}
