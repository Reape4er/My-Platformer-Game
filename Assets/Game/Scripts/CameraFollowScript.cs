using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float followSpeed = 1;
    private void Awake()
    {
        transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            y = playerTransform.position.y,
            z = playerTransform.position.z - 10,
        };
    }

    private void Update()
    {
        if (playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x,
                y = playerTransform.position.y,
                z = playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, followSpeed * Time.deltaTime);
            transform.position = pos;
        }

        
    }
}
