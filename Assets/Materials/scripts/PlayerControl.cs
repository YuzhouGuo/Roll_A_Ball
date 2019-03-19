using UnityEngine;
using UnityEngine.UI;

/** We want to check every frame for player input, and then we wan to apply 
 * that input to the player game object every frame has movement.*/

/** The Update method is called before rendering a frame, which is where most
 * game code will go*/

/** FixedUpdate, on the other hand, is called before any physics calculations,
 * and this is where our physics code will go*/

/** Search for API, on Mac, "Command + single quote"*/

public class PlayerControl : MonoBehaviour {

    //This variable will show up in the inspector as an editable property.
    public float forceAccepted;
    public float speed;
    public Text countText;
    public Text WinText;

    //Create a variable to hold the reference.
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }

    void FixedUpdate()
    {
        /** These two variables record the input from the horizontal and 
         * vertical axis, which are controlled by keys on a keyboard.*/
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //The x,y,z value will determine the force we add to the ball.
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            WinText.text = "You Win!";
        }
    }

    void OnCollisionEnter(Collision c)
    {
        // If the object we hit is the enemy
        if (c.gameObject.CompareTag("pusher"))
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * forceAccepted);
        }
    }

}

/** Static colliders should not move, like walls and floors. Dynamic colliders 
 * can move, and have a rigid body attached. Standard rigid body are moved using
 * physics forces. Kinematic rigid bodies are moved using their transform. */
