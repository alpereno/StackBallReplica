using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform playerT;

    [SerializeField] private Vector3 offSet;
    [SerializeField] [Range(0.01f, 1f)]
    float smoothSpeed = .125f;

    Vector3 velocity = Vector3.zero;

    void Start()
    {
        playerT = GameObject.FindObjectOfType<Player>().transform;
    }

    private void LateUpdate()
    {
        //It doesn't give an error when player destroyed
        if (playerT !=null)
        {
            Vector3 lookPosition = playerT.position + offSet;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, lookPosition, smoothSpeed);
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, lookPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
