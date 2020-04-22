using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent navAgent;

    float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveTo (Vector3 point)
    {
        navAgent.SetDestination(point);
    }

    public void FollowTarger(Interactable newTarget)
    {
        navAgent.stoppingDistance = newTarget.interactRadius * .8f;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        navAgent.stoppingDistance = 0f;

        target = null;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
