using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public delegate void OnRotateStage();
public enum CurrentlyFacing { Front, Left, Back, Right }
public class Player : MonoBehaviour
{
    public OpenDoor openDoor;

    public CurrentlyFacing facingDirection;

    public float movementSpeed;
    public float jumpForce;

    public BoxCollider frontFacingCollider;

    bool canFlip;
    GameObject flipper;

    bool inFrontOfDoor;
    GameObject door;

    Rigidbody rb;
    
    int batteryCount;
    GameObject[] doors;

    public InteractionScript NPCScript;
    TalkingToNPCScript npc;
        
    public CinemachineVirtualCamera cmvc;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        if(facingDirection == CurrentlyFacing.Front)
        {
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
        }
        else if (facingDirection == CurrentlyFacing.Left)
        {
            transform.position += new Vector3(0, 0, -movement) * Time.deltaTime * movementSpeed;
        }
        else if (facingDirection == CurrentlyFacing.Back)
        {
            transform.position += new Vector3(-movement, 0, 0) * Time.deltaTime * movementSpeed;
        }
        else if (facingDirection == CurrentlyFacing.Right)
        {
            transform.position += new Vector3(0, 0, movement) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.E) && NPCScript != null)
        {
            npc.InteractWithObject();
        }
    }

    public void SetNPC(InteractionScript npcScript)
    {
        NPCScript = npcScript;
        npc = (TalkingToNPCScript)NPCScript;
        Debug.Log("A");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("no");
        if (other.gameObject.tag == "Flipper")
        {
            //other.gameObject.GetComponent<FlipperScript>().PlayerOnIt();
            canFlip = true;
            flipper = other.gameObject;
        }
        else if (other.gameObject.tag == "Door")
        {
            door = other.gameObject;
            inFrontOfDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("help");
        if (other.gameObject.tag == "Flipper")
        {
            //other.gameObject.GetComponent<FlipperScript>().PlayerOffIt();
            canFlip = false;
            flipper = null;
        }
        else if (other.gameObject.tag == "Door")
        {
            door = null;
            inFrontOfDoor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
        }
    }

    public void FlipLeft()
    {
        //rb.isKinematic = true;
        ////cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.x, cam.transform.rotation.y + 90, cam.transform.rotation.z);

        //switch (facingDirection)
        //{
        //    case CurrentlyFacing.Front:
        //        transform.position = new Vector3(Mathf.Ceil(transform.position.x), transform.position.y, flipper.transform.position.z);
        //        rb.AddForce(-rb.velocity, ForceMode.Impulse);
        //        transform.rotation = Quaternion.Euler(0, 90, 0);

        //        cmvc.transform.rotation = transform.rotation;
        //        facingDirection = CurrentlyFacing.Left;
        //        break;

        //    case CurrentlyFacing.Left:
        //        transform.position = new Vector3(flipper.transform.position.x, transform.position.y, Mathf.Floor(transform.position.z));
        //        rb.AddForce(-rb.velocity, ForceMode.Impulse);
        //        transform.rotation = Quaternion.Euler(0, 180, 0);

        //        cmvc.transform.rotation = Quaternion.Euler(0, 180, 0);
        //        facingDirection = CurrentlyFacing.Back;
        //        break;

        //    case CurrentlyFacing.Back:
        //        transform.position = new Vector3(Mathf.Ceil(transform.position.x), transform.position.y, flipper.transform.position.z);
        //        rb.AddForce(-rb.velocity, ForceMode.Impulse);
        //        transform.rotation = Quaternion.Euler(0, 270, 0);

        //        cmvc.transform.rotation = Quaternion.Euler(0, 270, 0);
        //        facingDirection = CurrentlyFacing.Right;
        //        break;

        //    case CurrentlyFacing.Right:
        //        transform.position = new Vector3(flipper.transform.position.x, transform.position.y, Mathf.Floor(transform.position.z));
        //        rb.AddForce(-rb.velocity, ForceMode.Impulse);
        //        transform.rotation = Quaternion.Euler(0, 0, 0);

        //        cmvc.transform.rotation = transform.rotation;
        //        facingDirection = CurrentlyFacing.Front;
        //        break;
        //}

        //cam.transform.rotation = Quaternion.Euler()
        //transform.Rotate(transform.position, 90);
    }

    public int BatteriesCollected()
    {
        return batteryCount;
    }

    public Rigidbody RB()
    {
        return rb;
    }

    public void IncrementBatteryCounter()
    {
        batteryCount++;
        //PlayerManager.instance.ui.UpdateBatteryDisplay(batteryCount);
    }
}
