using Assets.Scripts;
using UnityEngine;

public class Playermovement : MonoBehaviour
{    
    private Rigidbody2D player;

    public float speed;  

    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        player = GetComponent<Rigidbody2D>();
    }


    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {        
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3? playerRotation = null;
        Vector2? playerDirection = null;
        RigidbodyConstraints2D? playerBodyConstraints = null;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerRotation = new Vector3(0, 0, 270);
            playerDirection = Vector2.up;
            playerBodyConstraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerRotation = new Vector3(0, 0, 90);
            playerDirection = Vector2.down;
            playerBodyConstraints = RigidbodyConstraints2D.FreezePositionX;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerRotation = new Vector3(0, 0, 0);
            playerDirection = Vector2.left;
            playerBodyConstraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerRotation = new Vector3(0, 0, 180);
            playerDirection = Vector2.right;
            playerBodyConstraints = RigidbodyConstraints2D.FreezePositionY;
        }

        if (playerRotation.HasValue)
        {
            player.transform.localEulerAngles = playerRotation.Value;
            player.AddForce(playerDirection.Value * speed);
            player.constraints = playerBodyConstraints.Value;

            GameDataStore.Instance.CurrentPlayerDirection = playerDirection.Value;
            GameDataStore.Instance.CurrentPlayerSpeed = speed;
        }
    }
}
