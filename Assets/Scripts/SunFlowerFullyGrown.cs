using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerFullyGrown : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion rotationCur;
    private Vector3 scaleCur;
    void Start()
    {
        rotationCur = Quaternion.Euler(-90, -90, 0);
        scaleCur = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotationCur;
        transform.localScale = scaleCur;
    }
}
