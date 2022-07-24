using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public float followSpeed = 0.9f;
    private float offset = -10f;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        movement.z = offset;
        movement.x = Mathf.Lerp(transform.position.x, player.transform.position.x, followSpeed);
        transform.localPosition = movement;
    }
}
