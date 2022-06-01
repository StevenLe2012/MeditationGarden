using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowthB : MonoBehaviour
{
    public float timeNeededToGrow = 5f;
    //private GameObject seed = null;
    public GameObject fullyGrownPlant = null;
    private static float timeWatered = 0;
    private bool hasGrown = false;
    private Vector3 positionCur; 
    private Quaternion rotationCur;

    void Start()
    {
        positionCur = transform.position;
        rotationCur = transform.rotation;
    }

    void OnTriggerStay(Collider other)
    {
        if (!hasGrown)
        {
            Debug.Log("Testing to see if it collides");
            if (other.gameObject.tag == "growBox")
            {
                timeWatered += Time.fixedDeltaTime;
                Debug.Log("Time watered is: " + timeWatered);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGrown)
        {
            if (timeWatered >= timeNeededToGrow)
            {
                Debug.Log("Plant now grew!");
                Instantiate(fullyGrownPlant, transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(gameObject);
                //gameObject.SetActive(false);
                //fullyGrownPlant.gameObject.SetActive(true);

                //fullyGrown();
                hasGrown = true;
            }

        }
        transform.position = positionCur;
        transform.rotation = rotationCur;
    }
}
