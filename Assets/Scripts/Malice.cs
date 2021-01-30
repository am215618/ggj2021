using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malice : MonoBehaviour
{
    public BoxCollider2D boxColliderUpFront;
    public Vector3[] positions;

    public enum State { Nothing, Roam, Chase }
    public State state;

    int pointNo = 0;
    Vector3 currentMoveTo;

    float tolerance;
    public float speed;
    public float delay;

    float delayStart;

    public float radiusNeededForChasing;

    bool enteredKeyRoom;

    // Start is called before the first frame update
    void Start()
    {
        if (positions.Length > 0)
            currentMoveTo = positions[0];

        tolerance = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == State.Roam)
        {
            if (transform.position != currentMoveTo)
            {
                Move();
            }
            else
            {
                UpdateTarget();
            }
        }
        else if (state == State.Chase)
        {
            ChasePlayer();
        }
    }

    void Move()
    {
        Vector3 heading = currentMoveTo - transform.position;
        if(state == State.Roam)
            transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        else if (state == State.Chase)
            transform.position += (heading / heading.magnitude) * speed * 2 * Time.deltaTime;

        if (heading.magnitude < tolerance)
        {
            transform.position = currentMoveTo;
        }
    }

    void UpdateTarget()
    {
        if (state == State.Roam)
        {
            if (Time.time - delayStart > delay)
                NextPlatform();
        }
        else if(state == State.Chase)
        {
            currentMoveTo = PlayerManager.instance.player.transform.position;
        }
    }

    void NextPlatform()
    {
        pointNo++;
        if (pointNo >= positions.Length)
            pointNo = 0;

        currentMoveTo = positions[pointNo];
    }

    public void StartChasingPlayer()
    {
        state = State.Chase;

    }

    public void ChasePlayer()
    {
        float distanceFromPlayer = Vector3.Distance(currentMoveTo, transform.position);

        if (distanceFromPlayer >= radiusNeededForChasing)
            Move();
        else
            state = State.Roam;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusNeededForChasing);
    }
}
