
using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D rb2d;
    //Store a reference to the Rigidbody2D component required to use 2D Physics.
    // Use this for initialization

    
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {



        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
      

     


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 270);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }




        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(Vector2.up * speed);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.AddForce(Vector2.down * speed);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * speed);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * speed);
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        }


        Debug.Log("hehhehe");
    }
}
