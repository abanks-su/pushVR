using UnityEngine;
using System.Collections;

public class TeleportWarp : MonoBehaviour
{
    public Transform Player;
    public Transform Head;
    public Transform rightHand;
    public Transform leftHand;

    public Transform WarpPoint1;
    public Transform WarpPoint2;

    public bool atWarp1 = false;
    public bool atWarp2 = true;

    public bool jumping = false;
    public bool landed = false;
    public float height = 0;
    public float jumpHeight = 0.3F;

    public float headpos = 0;


    public int timer = 0;
    public int time = 150;


    // Use this for initialization
    void Start ()
    {
        Player.position = WarpPoint2.position;
        height = Head.position.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        headpos = Head.position.y;

        if (Head.position.y > height + jumpHeight)
        {
            //If the Player is greater than their standard height plus .3 they are jumping
            jumping = true;
        }

        if (jumping && atWarp1 == false && atWarp2 == true)
        {
            // If the Player is Jumping and they are not at Warp1 Teleport them to Warp1
            Player.position = Vector3.MoveTowards(transform.position, WarpPoint1.position, 2);
            jumping = false;
            timer = 0;
        }

        if (Player.position == WarpPoint1.position)
        {
            timer++;

            if (timer > time)
            {
                atWarp1 = true;
                atWarp2 = false;
            }  
        }

        if (jumping && atWarp1 == true && atWarp2 == false)
        {
            // If the Player is Jumping and they are not at Warp1 Teleport them to Warp1
            Player.position = Vector3.MoveTowards(transform.position, WarpPoint2.position, 2);
            jumping = false;
            timer = 0;
        }

        if (Player.position == WarpPoint2.position)
        {
            timer++;

            if (timer > time)
            {
                atWarp2 = true;
                atWarp1 = false;
            }
        }



        /*
        if (Head.position.y > height + .3 && warp == false)
        {
            Player.position = WarpPoint.position; 
        }

        if (Player.position == WarpPoint.position)
        {
            warp = true;
        }
        */
    }
}
