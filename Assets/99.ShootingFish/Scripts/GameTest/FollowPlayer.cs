using System;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public bool allowDampMotion = false;
    
    private Transform playerTransform => GameManager.Instance.player.transform;

    private void Update()
    {
        if (playerTransform == false) return;

        Vector3 pos = playerTransform.position;
        pos.z = transform.position.z;
        
        transform.position = allowDampMotion == false ? pos : Vector3.Lerp(transform.position, pos, 0.1f);
    }
}
