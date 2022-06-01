using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    //private LineRenderer lineRenderer = null;
    //private ParticleSystem splashParticle = null;
    private ParticleSystem waterParticles = null;
    private Transform wateringcanRotation = null;

    private Coroutine pourRoutine = null;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 debugLocation;

    private void Awake()
    {
        //lineRenderer = GetComponent<LineRenderer>();
        //splashParticle = GetComponent<ParticleSystem>();
        waterParticles = GetComponent<ParticleSystem>();
        wateringcanRotation = GetComponent<Transform>();
    }

    private void Start()
    {
        //MoveToPosition(0, transform.position);
        //MoveToPosition(1, transform.position);
    }

    public void Begin()
    {
        //StartCoroutine(UpdateParticle());
        pourRoutine = StartCoroutine(BeginPour());
    }

    private IEnumerator BeginPour()
    {
        while (gameObject.activeSelf)
        {
            targetPosition = FindEndPoint();

            //MoveToPosition(0, transform.position);
            //AnimateToPosition(1, targetPosition);

            yield return null;
        }

    }

    private void End()
    {
        StopCoroutine(pourRoutine);
        pourRoutine = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour()
    {
        //while (!HasReachedPosition(0, targetPosition))
        //{
        //AnimateToPosition(0, targetPosition);
        //AnimateToPosition(1, targetPosition);

        //yield return null;
        //}

        Destroy(gameObject);
        yield return null; //
    }


    private Vector3 FindEndPoint()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        Physics.Raycast(ray, out hit, 2.0f);
        //Debug.Log(hit.collider);
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);
        debugLocation = endPoint;
        return endPoint;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(debugLocation, 0.1f);
    }

    //private void MoveToPosition(int index, Vector3 targetPostion)
    //{
    //    lineRenderer.SetPosition(index, targetPosition);
    //}

    //private void AnimateToPosition(int index, Vector3 targetPosition)
    //{
    //Vector3 currentPoint = lineRenderer.GetPosition(index);
    //Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
    //lineRenderer.SetPosition(index, newPosition);
    //}

    //private bool HasReachedPosition(int index, Vector3 targetPosition)
    //{
    //Vector3 currentPosition = lineRenderer.GetPosition(index);
    //return currentPosition == targetPosition;
    //}

    //private IEnumerator UpdateParticle()
    //{
    //while(gameObject.activeSelf)
    //{
    //splashParticle.gameObject.transform.position = targetPosition;

    //bool isHitting = HasReachedPosition(1, targetPosition);
    //splashParticle.gameObject.SetActive(isHitting);

    //yield return null;
    //}
    //}

    private void Update() // TODO: MAKE THIS STREAM ALWAYS POINT DOWN SOMEHOW (change transform.roatation)
    {
        //Quaternion currentRotation = wateringcanRotation.gameObject.transform.rotation
        waterParticles.gameObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        //Quaternion currentRotation = wateringcanRotation.rotation;
        //currentRotation.Set(0f, 0f, 0f, 0f);

    }
}
