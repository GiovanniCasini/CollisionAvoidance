using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float offset;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z + offset);
    }
}
