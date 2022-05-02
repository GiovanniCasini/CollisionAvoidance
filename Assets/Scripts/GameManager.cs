using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<GameObject> ground;
    public Transform player;
    public GameObject global;

    bool gameHasEnded = false;
    private float offset = 60f;
    public float restartDelay = 1f;

    [HideInInspector]
    public bool godmode = false;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnGround()
    {
        GameObject moveGround = ground[0];
        float x = moveGround.transform.position.x;
        float y = moveGround.transform.position.y - 0.06f;
        ground.Remove(moveGround);
        float newZ = ground[ground.Count - 1].transform.position.z + offset;
        moveGround.transform.position = new Vector3(x, y, newZ);
        ground.Add(moveGround);
    }

    public void LowPlayer()
    {
        float x = player.transform.position.x;
        float newY = player.transform.position.y - 0.01f;
        float z = player.transform.position.z;
        player.transform.position = new Vector3(x, newY, z);
    }

    public void EnterGodMode(float duration)
    {
        global.GetComponent<PostProcessingManager>().GodMode(duration);
    }

    public void ResetValuesPP()
    {
        global.GetComponent<PostProcessingManager>().ResetValues();
    }
}
