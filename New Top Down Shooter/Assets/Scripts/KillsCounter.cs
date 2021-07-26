using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsCounter : MonoBehaviour
{

    Text myText;
    public static int kills = 0;



    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        myText.text = kills.ToString();
    }

    public void AddKill() { kills++; }
}
