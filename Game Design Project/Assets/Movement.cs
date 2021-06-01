using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;
    public Vector3 targetPosition;


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(targetPosition);

        Quaternion rotationToLookAt = Quaternion.LookRotation(targetPosition - transform.position);
        float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            rotationToLookAt.eulerAngles.y,
            ref rotateVelocity,
            rotateSpeedMovement * (Time.deltaTime * 5));

        transform.eulerAngles = new Vector3(0, rotationY, 0);

        /*
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Check che stiamo hittando un navmesh system
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //Player deve muoversi verso hit point
                agent.SetDestination(hit.point);


                //Rotazione
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
                   
            }
        }
        */
    }
}
