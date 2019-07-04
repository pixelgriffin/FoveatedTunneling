using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Placer : MonoBehaviour
{
    public GameObject pointPrefab;
    [Tooltip("The distance between waypoints in meters")]
    public float distanceBetweenPoints = 2f;

    [Tooltip("The amount in meters to modify the place height")]
    public float yChange = 0f;

    public Transform player;

    [Tooltip("Here you can define any functions in scripts to call when a waypoint is reached. Sample things like player position and current time.")]
    public UnityEvent OnPointConsumed;
}
