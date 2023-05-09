using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStare : MonoBehaviour
{
    public Transform target; // The object to follow
    public float followSpeed = 2f; // The speed at which to follow the target
    public float distanceFromTarget = 2f; // The minimum distance to maintain from the target
    public float obstacleDistance = 1f; // The distance at which to detect obstacles
    public float avoidSpeed = 2f; // The speed at which to move away from obstacles
    public float teleportDistance = 10f; // The distance at which to teleport the object
    public LayerMask obstacleLayer; // The layer to check for obstacles

    private bool avoidingObstacle = false; // Flag to indicate if the monster is currently avoiding an obstacle

    void Update()
    {
        // Calculate the position to move to
        Vector3 targetPos = target.position;
        targetPos.y = transform.position.y; // Keep the y position fixed
        Vector3 moveDir = (targetPos - transform.position).normalized;

        // Check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, obstacleDistance, obstacleLayer))
        {
            // If an obstacle is detected, move away from it
            Vector3 avoidDir = Vector3.Cross(Vector3.up, hit.normal);
            transform.position += avoidDir.normalized * avoidSpeed * Time.deltaTime;
            avoidingObstacle = true;
        }
        else
        {
            avoidingObstacle = false;
        }

        // Move towards the target if not avoiding an obstacle
        if (!avoidingObstacle)
        {
            float distanceToTarget = Vector3.Distance(transform.position, targetPos);
            if (distanceToTarget < distanceFromTarget)
            {
                transform.position = targetPos - moveDir * distanceFromTarget;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
            }
        }

        // Calculate the direction to look at
        Vector3 direction = target.position - transform.position;
        direction.y = 0; // Ignore the y component
        if (direction != Vector3.zero) // Only update rotation if direction is not zero
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // Teleport the object if it gets too far away from the player
        if (Vector3.Distance(transform.position, target.position) > teleportDistance)
        {
            Vector3 newPos = target.position + moveDir * distanceFromTarget;
            newPos.y = transform.position.y;
            transform.position = newPos;
        }
    }
}