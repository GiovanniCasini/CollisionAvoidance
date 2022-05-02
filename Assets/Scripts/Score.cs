using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnManager;
    public Text scoreText;
    private bool speedIncreased = false;
    private bool spawningIncreased = false;

    private int startOffset = 134;

    // Update is called once per frame
    void Update()
    {
        float pos = player.transform.position.z;
        if(pos > startOffset)
            scoreText.text = ((pos - startOffset) / 5).ToString("0");


        if ((int)((pos - startOffset) / 5) % 50 == 0 && (pos - startOffset) / 5 > 1f)
        {
            if (speedIncreased == false)
            {
                player.GetComponent<PlayerMovement>().IncreaseSpeed(100f);
                speedIncreased = true;
            }
        }
        else
        {
            speedIncreased = false;
        }

        if (((int)((pos - startOffset) / 5) == 100 || (int)((pos - startOffset) / 5) == 250 || (int)((pos - startOffset) / 5) == 600) && pos/5 > 1f)
        {
            if (spawningIncreased == false)
            {
                spawnManager.GetComponent<SpawnManager>().IncreaseSpawning();
                spawningIncreased = true;
            }
        }
        else
        {
            spawningIncreased = false;
        }


    }

    
}
