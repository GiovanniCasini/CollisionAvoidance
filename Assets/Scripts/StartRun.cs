using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRun : MonoBehaviour
{
    public GameObject effect;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(effect, transform.position, other.transform.rotation) as GameObject, 3f);
            other.GetComponent<PlayerMovement>().IncreaseSpeed(1800f);
            ScreenShake.instance.StartShake(1f, 0.05f, 50f);
            Vibrator.Vibrate(250);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("drop");
        }
    }

}
