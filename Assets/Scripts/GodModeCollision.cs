using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodModeCollision : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject godmodeEffect;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Destroy(Instantiate(effect, transform.position, other.transform.rotation) as GameObject, 3f);
            //other.GetComponent<PlayerMovement>().IncreaseSpeed(1800f);
            Destroy(Instantiate(godmodeEffect, transform.position, other.gameObject.transform.rotation) as GameObject, 2f);
            ScreenShake.instance.StartShake(1f, 0.05f, 50f);
            Vibrator.Vibrate(250);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Pause("drop", "godmode");
            //FindObjectOfType<AudioManager>().Play("godmode");

            CoroutineManager.Instance.StopAllCoroutines();
            CoroutineManager.Instance.StartCoroutine(GodModeCountdownCoroutine(10f)); //GODMODE DURATION

            CoroutineManager.Instance.StartCoroutine(GodModeShakeCoroutine());

            other.GetComponent<PlayerMovement>().EnterGodMode();

            gameManager.GetComponent<GameManager>().EnterGodMode(10f); //GODMODE DURATION

            gameManager.godmode = true;
        }
    }

    IEnumerator GodModeCountdownCoroutine(float durationGodMode)
    {
        float timePassed = 0.0f;
        while (timePassed < durationGodMode)
        {
            timePassed += Time.deltaTime;
            yield return null;
        }
        FindObjectOfType<PlayerMovement>().ExitGodMode();
        gameManager.GetComponent<GameManager>().ResetValuesPP();
        gameManager.godmode = false;
        CoroutineManager.Instance.StopAllCoroutines();
    }

    IEnumerator GodModeShakeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.4f);
            ScreenShake.instance.StartShake(0.2f, 0.04f, 40f);
            Vibrator.Vibrate(200);
        }
    }
}
