using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DestroyObs", 1f, 3f);
    }

    void DestroyObs()
    {
        if (transform.position.y <= -1f)
        {
            Destroy(gameObject);
            return;
        }
    }
}
