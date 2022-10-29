using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f, 10f)] float fltSpeed = 1f;
    
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float fltTravelPercent = 0f;

            transform.LookAt(endPosition);

            while (fltTravelPercent < 1f)
            {
                fltTravelPercent += Time.deltaTime * fltSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, fltTravelPercent);
                yield return new WaitForEndOfFrame();
            }


        }
    }
}
