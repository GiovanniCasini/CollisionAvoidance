using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject desVersion;
    
    public void DesObstacle(bool godmode)
    {
        if (!godmode)
        {
            Instantiate(desVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
