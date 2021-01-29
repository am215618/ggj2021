using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.05f;
    public float gridCellSize;
    public Transform movePoint;

    public LayerMask collisionLayer;
    public LayerMask doorLayer;

    Door[] doors;
    float closestDistanceToDoor;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.transform.parent = null;
        doors = FindObjectsOfType<Door>();
    }

    void Update()
    {
        //movePoint.transform.position = new Vector3(Input.GetAxis("Horizontal") * gridCellSize, Input.GetAxis("Vertical") * gridCellSize, 0f));

        //if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, collisionLayer))
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (transform.position == movePoint.position)
        {
            if (Vector3.Distance(transform.position, movePoint.position) <= 0.16f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * gridCellSize, 0f, 0f), .16f, collisionLayer))
                    {
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * gridCellSize, 0f, 0f);
                    }
                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * gridCellSize, 0f), .16f, collisionLayer))
                    {
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * gridCellSize, 0f);
                    }
                }

                if(Physics2D.OverlapCircle(movePoint.position, .32f, doorLayer))
                {
                    foreach (Door door in doors)
                    {
                        float distance = Vector2.Distance(door.transform.position, transform.position);

                        if(distance <= .32f)
                        {
                            door.OpenDoor();
                        }
                    }
                }
            }
        }
    }
}
