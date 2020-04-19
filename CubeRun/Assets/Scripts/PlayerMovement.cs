using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Refers to Rigidbody in Unity
    public Rigidbody rb;

    public float forwardForce = 0f;
    public float sidewaysForce = 500f;

    void FixedUpdate()
    {
        //Add A ForwardForce
        rb.AddForce(0,0,forwardForce*Time.deltaTime);

        if (Input.GetKey("d"))
        {

            rb.AddForce(sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);

        }

        if (Input.GetKey("a"))
        {

            rb.AddForce(-sidewaysForce * Time.deltaTime,0,0, ForceMode.VelocityChange);

        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<Game_Manager>().EndGame();
        }


    }
}
