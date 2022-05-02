using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameObject effectPlayer;
    public GameObject effectObject;
    public GameObject gotHitScreen;
    public GameManager gameManager;

    /*void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Instantiate(effect, transform.position, collisionInfo.gameObject.transform.rotation);
            collisionInfo.collider.GetComponent<Destructable>().DesObstacle(gameManager.godmode);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gotHit();
            ScreenShake.instance.StartShake(1.5f, 0.15f, 100f);
            Vibrator.Vibrate(1000);
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }*/

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gotHitScreen = FindObjectOfType<Image>().gameObject;
        movement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !gameManager.godmode)
        {
            //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Destroy(Instantiate(effectPlayer, transform.position, other.gameObject.transform.rotation) as GameObject, 2f);
            gameObject.GetComponent<Destructable>().DesObstacle(gameManager.godmode);
            other.GetComponent<Rigidbody>().useGravity = true;
            gotHit();
            ScreenShake.instance.StartShake(1.5f, 0.15f, 100f);
            Vibrator.Vibrate(1000);
            movement.enabled = false;
            gameManager.EndGame();
        } else if (other.tag == "Player" && gameManager.godmode)
        {
            Destroy(Instantiate(effectObject, transform.position, other.gameObject.transform.rotation) as GameObject, 2f);
            gameObject.GetComponent<Destructable>().DesObstacle(gameManager.godmode);
            //other.GetComponent<Rigidbody>().useGravity = true;
            //gotHit();
            ScreenShake.instance.StartShake(1.5f, 0.15f, 100f);
            Vibrator.Vibrate(500);
            //movement.enabled = false;
            //gameManager.EndGame();
        }

    }

    public void gotHit()
    {
        var color = gotHitScreen.GetComponent<Image>().color;
        color.a = 0.6f;
        gotHitScreen.GetComponent<Image>().color = color;
    }

    private void Update()
    {
        if(gotHitScreen != null) {

            if (gotHitScreen.GetComponent<Image>().color.a > 0)
            {
                var color = gotHitScreen.GetComponent<Image>().color;
                color.a -= 0.005f;
                gotHitScreen.GetComponent<Image>().color = color;
            }
        }
        
    }
}
