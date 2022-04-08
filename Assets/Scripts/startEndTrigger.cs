using System.Diagnostics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class startEndTrigger : MonoBehaviour
{
    static Stopwatch stopWatch = new Stopwatch();
    public Text timer;

    public void OnTriggerEnter(Collider other)

    {

        if (other.name == "startTrigger")
        {

            stopWatch.Start();
        }
        if (other.name == "endTrigger")
        {
            stopWatch.Stop();

            timer.text = "Elapsed Time: "+(stopWatch.Elapsed.ToString()).Substring(0,10);



        }
    }
}