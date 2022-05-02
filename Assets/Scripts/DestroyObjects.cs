using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Booster" || other.tag == "Obstacle")
        {
            Destroy(other.gameObject);           
        }
    }
}
