using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    //public float forwardForce = 2000f;
    public float speed = 50f;
    public float sidewaysForce = 500f;
    private float screenWidth;

    [HideInInspector]
    public bool godmode = false;

    void Start()
    {
        screenWidth = Screen.width;
    }

    void FixedUpdate()
    {
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);

        /*Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);*/

        if (Input.GetKey("d"))
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("a"))
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        
        //mobile controls
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).position.x > screenWidth / 2)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
            if (Input.GetTouch(0).position.x < screenWidth / 2)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }

        if (rb.position.y < -1f || rb.position.x < -14.75 || rb.position.x > 0.45)
        {
            rb.useGravity = enabled;
            rb.AddForce(0, -1000, 0);
            this.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void IncreaseSpeed(float increase)
    {
        speed += increase;
    }

    public void EnterGodMode()
    {
        if (!godmode)
        {
            godmode = true;
            IncreaseSpeed(2000f);
        }
    }

    public void ExitGodMode()
    {
        IncreaseSpeed(-2000f);
        godmode = false;
    }
}
