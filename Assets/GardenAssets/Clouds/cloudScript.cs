using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour
{
    //spawn variables
    public GameObject spawnCloud;
    private int cloudCount = 0;
    private int cloudLimit = 1;

    //timer
    public float timeLeft = 2f;
    public float timer    = 1f;


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //if there isn't a cloud
        if (cloudCount != cloudLimit)
        {
            GameObject newCloud = Instantiate(spawnCloud, transform.position, Quaternion.identity);
            cloudCount++;
        }

        if (timeLeft < 0)
        {
            transform.Translate((-1) * Time.deltaTime, (-2) * Time.deltaTime, 0);
        }

        if (cloudCount == cloudLimit)
        {
            SelfDestroy();
        }
    }

    public IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
        cloudCount--;
    }

    public void spawn()
    {
        GameObject newCloud = Instantiate(spawnCloud, transform.position, Quaternion.identity);
        newCloud.GetComponent<Rigidbody>().velocity = transform.forward;
        newCloud.transform.parent = transform;
        cloudCount++;
    }

}
