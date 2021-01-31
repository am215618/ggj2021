using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Dialogue }
public class PlayerController : MonoBehaviour
{
    public PlayerState state;

    public Animator animator;
    public bool vInput;
    public bool hInput;

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
        if (state == PlayerState.Normal)
        {
            //movePoint.transform.position = new Vector3(Input.GetAxis("Horizontal") * gridCellSize, Input.GetAxis("Vertical") * gridCellSize, 0f));

            //if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, collisionLayer))
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

            if (transform.position == movePoint.position)
            {
                float hMove = Input.GetAxisRaw("Horizontal");
                float vMove = Input.GetAxisRaw("Vertical");

                animator.SetFloat("HorizontalDirection", hMove);
                animator.SetFloat("VerticalDirection", vMove);

                if (hMove == 0 && vMove == 0)
                {
                    animator.SetBool("InputPressed", false);
                }
                if (hMove == 0)
                {
                    hInput = false;
                }
                if (vMove == 0)
                {
                    vInput = false;
                }

                if (hMove == 0 && vMove == 0)
                {
                    animator.SetBool("InputPressed", false);
                    vInput = false;
                    hInput = false;
                }

                if (Vector3.Distance(transform.position, movePoint.position) <= 0.16f)
                {
                    if (!vInput)
                    {
                        if (Mathf.Abs(hMove) == 1f)
                        {
                            hInput = true;
                            if (hMove == 1)
                            {
                                animator.SetBool("LastPressedRight", true);
                                animator.SetBool("LastPressedLeft", false);
                                animator.SetBool("LastPressedUp", false);
                                animator.SetBool("LastPressedDown", false);
                            }
                            else
                            {
                                animator.SetBool("LastPressedRight", false);
                                animator.SetBool("LastPressedLeft", true);
                                animator.SetBool("LastPressedUp", false);
                                animator.SetBool("LastPressedDown", false);
                            }

                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * gridCellSize, 0f, 0f), .12f, collisionLayer))
                            {
                                animator.SetBool("InputPressed", true);
                                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * gridCellSize, 0f, 0f);
                            }
                        }
                    }

                    if (!hInput)
                    {
                        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                        {
                            vInput = true;
                            if (vMove == 1)
                            {
                                animator.SetBool("LastPressedRight", false);
                                animator.SetBool("LastPressedLeft", false);
                                animator.SetBool("LastPressedUp", true);
                                animator.SetBool("LastPressedDown", false);
                            }
                            else
                            {
                                animator.SetBool("LastPressedRight", false);
                                animator.SetBool("LastPressedLeft", false);
                                animator.SetBool("LastPressedUp", false);
                                animator.SetBool("LastPressedDown", true);
                            }
                            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * gridCellSize, 0f), .12f, collisionLayer))
                            {
                                animator.SetBool("InputPressed", true);
                                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * gridCellSize, 0f);
                            }
                        }
                    }

                    if (Physics2D.OverlapCircle(movePoint.position, .32f, doorLayer))
                    {
                        foreach (Door door in doors)
                        {
                            float distance = Vector2.Distance(door.transform.position, transform.position);

                            if (distance <= .32f)
                            {
                                door.OpenDoor();
                            }
                        }
                    }
                }
            }
        }
    }

    public void SetPlayerState(PlayerState newState)
    {
        state = newState;
    }
}
