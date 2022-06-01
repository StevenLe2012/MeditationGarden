using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourMinThreshold = 45;
    public int pourMaxThreshold = 180;
    public Transform origin = null;
    public GameObject streamPrefab = null;
    public GameObject invisBox = null;

    private bool isPouring = false;
    private InvisGrowBox growBox = null;
    private Stream currentStream = null;
    private GameObject streamObject = null;
    private GameObject invisGrowBox = null;

    private void Update()
    {
        bool pourCheck = (CalculatePourAngle() < pourMinThreshold);

        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }


    }

    private void StartPour()
    {
        Debug.Log("Start");
        currentStream = CreateStream();
        currentStream.Begin();
        growBox = CreateInvisBox();
    }

    private void EndPour()
    {
        Debug.Log("End");
        Destroy(streamObject);
        Destroy(invisGrowBox);
        //currentStream.End();
        //currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg; //you could do transform.up.y depending on mesh or transform.forward.y
    }

    private Stream CreateStream()
    {
        streamObject = Instantiate(streamPrefab, origin.position, Quaternion.Euler(90f, 0f, 0f), transform);
        return streamObject.GetComponent<Stream>();
    }

    private InvisGrowBox CreateInvisBox()
    {
        invisGrowBox = Instantiate(invisBox, origin.position, Quaternion.identity, transform);
        return invisGrowBox.GetComponent<InvisGrowBox>();
    }
}
