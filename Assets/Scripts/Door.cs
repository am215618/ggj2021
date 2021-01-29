using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isLocked;

    bool closed;

    HingeJoint2D hinge;
    JointAngleLimits2D openLimits;
    JointAngleLimits2D closeLimits;

    private void Awake()
    {
        hinge = GetComponentInChildren<HingeJoint2D>();
        openLimits = hinge.limits;
        closeLimits = new JointAngleLimits2D { min = 0f, max = 0f };
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
            closed = false;
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else
        {
            gameObject.layer = 8;
        }
    }
}
