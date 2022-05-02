using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerExit(Collider other)
    {   
        if (other.tag == "Player")
        {
            //gameManager.SpawnGround(); 
            gameManager.LowPlayer();
            gameManager.Invoke("SpawnGround", 0.15f);
        }
    }

}
