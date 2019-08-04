using UnityEngine;
using System.Collections;

public class LiftFinal : MonoBehaviour
{

    public Transform head;
    public Transform rightHand;
    public Transform leftHand;

    public Transform Box1;

    public int Boxid = 0;
    public int numBoxes = 0;

    public Transform Trigger;
    public bool withinRadius = false;

    public Rigidbody box1Rb;

    public int counter = 0;
	public int counter2 = 0;

    public int PullPowerX = 15;
    public int PullPowerY = 15;
    public int PullPowerZ = 15;

    public int PushPower = 5;
    public int PushPowerMax = 5;

    public int PushPowerX = 15;
    public int PushPowerY = 0;
    public int PushPowerZ = 200;

    

    public float armLength = 0.5F;
    public float armLengthZ = 0.5F;

    public float headPos = 0;
    public float rightHandPos = 0;
    public float leftHandPos = 0;

    public bool RTclickedx = false;
    public bool LTclickedx = false;
    public bool rightHandGrippedx = false;
    public bool leftHandGrippedx = false;
    public bool allBoxLift = false;

    public bool rightHandDown = false;
    public bool leftHandDown = false;


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        //GameObject thePlayer = GameObject.Find("Controller (right)");

        SteamVR_TrackedController PlayerScript = rightHand.GetComponent<SteamVR_TrackedController>();
        counter = PlayerScript.counter;

        SteamVR_TrackedController RTclicked = rightHand.GetComponent<SteamVR_TrackedController>();
        RTclickedx = RTclicked.triggerClicked;

        SteamVR_TrackedController LTclicked = leftHand.GetComponent<SteamVR_TrackedController>();
        LTclickedx = LTclicked.triggerClicked;

        SteamVR_TrackedController rightHandGripped = rightHand.GetComponent<SteamVR_TrackedController>();
        rightHandGrippedx = rightHandGripped.gripDown;

        SteamVR_TrackedController leftHandGripped = leftHand.GetComponent<SteamVR_TrackedController>();
        leftHandGrippedx = leftHandGripped.gripDown;

        myTrigger playerScript2 = Trigger.GetComponent<myTrigger>();
        withinRadius = playerScript2.inThatHoe;

        // Each Pushable Box has an ID#
        // The counter corresponds to each Box's ID Number
        // Everytime the trigger is pressed the counter increases or decrease by one, cycling through the boxes in the scene
        // If the counter is equal to the box id then that box is targeted and can be moved


			
        if (withinRadius)
        {

            if (counter > numBoxes)
            {
                PlayerScript.counter = 0;
            }

            if (counter < 0)
            {
                PlayerScript.counter = numBoxes;
            }

			if (Input.GetKeyUp("joystick button 5")) 
			{
				PlayerScript.counter++;
			}

			if (Input.GetKeyUp("joystick button 4")) 
			{
				PlayerScript.counter--;
			}

            if (RTclickedx && LTclickedx)
            {
                allBoxLift = true;
            }
            else
            {
                allBoxLift = false;
            }

            // Checks to see if your right hand is down by its side
            if (rightHand.position.y < head.position.y &&
                rightHand.position.z > (head.position.z - armLength) &&
                rightHand.position.z < (head.position.z + armLength) &&
                rightHand.position.x > (head.position.x - armLength) &&
                rightHand.position.x < (head.position.x + armLength))
            {
                rightHandDown = true;
            }
            else
            {
                rightHandDown = false;
            }

            // Checks to see if your left hand is down by its side
            if (leftHand.position.y < head.position.y &&
                leftHand.position.z > (head.position.z - armLength) &&
                leftHand.position.z < (head.position.z + armLength) &&
                leftHand.position.x > (head.position.x - armLength) &&
                leftHand.position.x < (head.position.x + armLength))
            {
                leftHandDown = true;
            }
            else
            {
                leftHandDown = false;
            }

            if (counter == Boxid || allBoxLift)
            {
                if (allBoxLift)
                {
                    Boxid = 0;
                 }
                Box1.GetComponent<Renderer>().material.color = Color.blue;


				if (Input.GetAxis ("DPadY") > 0) 
				{
					box1Rb.AddForce(transform.up * PullPowerY);
				}

				if (Input.GetAxis ("DPadX") > 0) 
				{
					box1Rb.AddForce(transform.right * PullPowerX);
				}

				if (Input.GetAxis ("DPadX") < 0) 
				{
					box1Rb.AddForce(transform.right * -PullPowerX);
				}

                //Pull
                if (!rightHandGrippedx && !leftHandGrippedx)
                {
                    if (rightHandDown)
                    {
                        if (leftHand.position.y > head.position.y)
                        {
                            box1Rb.AddForce(transform.up * PullPowerY);
                        }

                        if (leftHand.position.x > (head.position.x + armLength))
                        {
                            box1Rb.AddForce(transform.right * PullPowerX);
                        }

                        if (leftHand.position.x < (head.position.x - armLength))
                        {
                            box1Rb.AddForce(transform.right * -PullPowerX);
                        }

                        if (leftHand.position.z > (head.position.z + armLength))
                        {
                            box1Rb.AddForce(transform.forward * PullPowerZ);
                        }

                        if (leftHand.position.z < (head.position.z - armLength))
                        {
                            box1Rb.AddForce(transform.forward * -PullPowerZ);
                        }
                    }

                    if (leftHandDown)
                    {
                        if (rightHand.position.y > head.position.y)
                        {
                            box1Rb.AddForce(transform.up * PullPowerY);
                        }

                        if (rightHand.position.x > (head.position.x + armLength))
                        {
                            box1Rb.AddForce(transform.right * PullPowerX);
                        }

                        if (rightHand.position.x < (head.position.x - armLength))
                        {
                            box1Rb.AddForce(transform.right * -PullPowerX);
                        }

                        if (rightHand.position.z > (head.position.z + armLength))
                        {
                            box1Rb.AddForce(transform.forward * PullPowerZ);
                        }

                        if (rightHand.position.z < (head.position.z - armLength))
                        {
                            box1Rb.AddForce(transform.forward * -PullPowerZ);
                        }
                    }
                }

                //Push
                if (!leftHandGrippedx && rightHandGrippedx)
                {
                    if (rightHand.position.z > (head.position.z + armLength))
                    {
                        box1Rb.AddForce(transform.forward * PushPowerZ);
                    }

                    if (rightHand.position.z < (head.position.z - armLength))
                    {
                        box1Rb.AddForce(transform.forward * -PushPowerZ);
                    }

                    if (rightHand.position.x > (head.position.x + armLength))
                    {
                        box1Rb.AddForce(transform.right * PushPowerX);
                    }

                    if (rightHand.position.x < (head.position.x - armLength))
                    {
                        box1Rb.AddForce(transform.right * -PushPowerX);
                    }

                    if (rightHand.position.y > (head.position.y + armLength))
                    {
                        box1Rb.AddForce(transform.up * PushPowerY);
                    }

                    if (rightHand.position.y < (head.position.y - armLength))
                    {
                        box1Rb.AddForce(transform.up * -PushPowerY);
                    }

                    PushPower--;
                }

                if (!rightHandGrippedx && leftHandGrippedx)
                {
                    if (leftHand.position.z > (head.position.z + armLength) )
                    {
                        box1Rb.AddForce(transform.forward * PushPowerZ);
                    }

                    if (leftHand.position.z < (head.position.z - armLength))
                    {
                        box1Rb.AddForce(transform.forward * -PushPowerZ);
                    }

                    if (leftHand.position.x > (head.position.x + armLength))
                    {
                        box1Rb.AddForce(transform.right * PushPowerX);
                    }

                    if (leftHand.position.x < (head.position.x - armLength))
                    {
                        box1Rb.AddForce(transform.right * -PushPowerX);
                    }

                    if (leftHand.position.y > (head.position.y + armLength))
                    {
                        box1Rb.AddForce(transform.up * PushPowerY);
                    }

                    if (leftHand.position.y < (head.position.y - armLength))
                    {
                        box1Rb.AddForce(transform.up * -PushPowerY);
                    }
                    PushPower--;
                }

				if (Input.GetKeyUp("joystick button 0")) 
				{
					box1Rb.AddForce(transform.forward * 1000);
				}

				if (Input.GetAxis ("DPadY") > 0 && Input.GetKeyDown("joystick button 0")) 
				{
					box1Rb.AddForce(transform.up * PushPowerY);
				}

				if (Input.GetAxis ("DPadX") > 0 && Input.GetKeyDown("joystick button 0")) 
				{
					box1Rb.AddForce(transform.up * -PushPowerY);
				}

				if (Input.GetAxis ("DPadX") < 0 && Input.GetKeyDown("joystick button 0")) 
				{
					box1Rb.AddForce(transform.right * -PushPowerX);
				}

                if (rightHandDown || leftHandDown)
                {
                    PushPower++;
                }

                if (PushPower > PushPowerMax)
                {
                    PushPower = PushPowerMax;
                }

                if (PushPower < 0)
                {
                    PushPower = 0;
                }
            }
            else
            {
                Box1.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
