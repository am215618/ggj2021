using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked;

    [SerializeField] AudioSource source;

    HingeJoint2D hinge;
    JointAngleLimits2D openLimits;
    JointAngleLimits2D closeLimits;

    public bool facingWest;

    private void Awake()
    {
        hinge = GetComponentInChildren<HingeJoint2D>();
        openLimits = hinge.limits;
        closeLimits = new JointAngleLimits2D { min = 0f, max = 0f };
        if (isLocked)
        {
            gameObject.layer = 8;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isLocked)
        {
            gameObject.layer = 8;
        }
    }

    public void OpenDoor()
    {
        Debug.Log("A");
        if (!isLocked)
        {
            source.Play();
            if (!facingWest)
            {
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            }
            else
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            }
        }
        else
        {
            gameObject.layer = 8;
        }
    }

    public void CloseDoor()
    {
        Debug.Log("C");
        if (!facingWest)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        gameObject.layer = 8;
        isLocked = true;
    }
}
