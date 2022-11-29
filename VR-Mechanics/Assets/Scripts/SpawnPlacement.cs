using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlacement : MonoBehaviour
{
    [SerializeField]
    private float distanceThreshold = 20.0f;

    /// <summary>
    /// The distance from the GameObject's spawn position at which will trigger a respawn.
    /// </summary>
    public float DistanceThreshold
    {
        get 
        {
            return distanceThreshold;
        }
        
        set
        {
            distanceThreshold = value;
            distanceThresholdSquared = distanceThreshold * distanceThreshold;
        }
    }

    private Vector3 localRespawnPosition;
    private Quaternion localRespawnRotation;
    private Rigidbody rigidBody;
    private float distanceThresholdSquared;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        LockSpawnPoint();
        distanceThresholdSquared = distanceThreshold * distanceThreshold;
    }

    private void LateUpdate()
    {
        float distanceSqr = (localRespawnPosition - transform.localPosition).sqrMagnitude;

        if (distanceSqr > distanceThresholdSquared)
        {
            // Reset any velocity from falling or moving when respawning to original location
            if (rigidBody != null)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.angularVelocity = Vector3.zero;
            }

            transform.localPosition = localRespawnPosition;
            transform.localRotation = localRespawnRotation;
        }
    }

    /// <summary>
    /// Updates the local respawn pose to the objects current pose.
    /// </summary>
    public void LockSpawnPoint()
    {
        localRespawnPosition = transform.localPosition;
        localRespawnRotation = transform.localRotation;
    }
}
