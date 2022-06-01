using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationManager : MonoBehaviour
{
    public GameObject player_rig;
    public GameObject destination;

    private bool is_aiming = false;
    private GameObject currentDestination;
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = Instantiate(destination, transform.position, Quaternion.identity);
    }

    public void SwitchAiming() {
        is_aiming = !is_aiming;

        if(!is_aiming) {
            currentDestination.SetActive(false);
        }
    }

    public void Teleport() {
        if (is_aiming && currentDestination.activeSelf) {
            player_rig.transform.position = currentDestination.transform.position;
            currentDestination.SetActive(false);
        }
    }

    private void checkForDestination() {
        Ray ray = new Ray(transform.position, transform.rotation * Vector3.down);

        RaycastHit hit;

        bool b = Physics.Raycast(ray, out hit, 10, 1);

        if (b) {
            currentDestination.transform.position = hit.point;
            currentDestination.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (is_aiming) {
            checkForDestination();
        }
    }
}
