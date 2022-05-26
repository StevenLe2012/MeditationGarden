using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMovement : MonoBehaviour
{
    //timers
    public float timeLeft = 2f;
    // Update is called once per frame
    void Update()
    {
        //wait for (timeLeft) and then move continuously
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            transform.Translate((-1) * Time.deltaTime, (-2) * Time.deltaTime, 0);
        }
    }
}