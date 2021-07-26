using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyKills : MonoBehaviour
{
    Text myText;

    int myKills = KillsCounter.kills;


    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = myKills.ToString();
    }

   
}
