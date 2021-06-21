using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    public float rotateSpeedMovement = 10;
    float rotateVelocity = 0;
    public Vector3 targetPosition;
    public GameObject enemy;
    public Animator animator; 


    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        targetPosition = transform.position;
        animator.SetFloat("moves", 0);
    }

    void Update()
    {
        agent.SetDestination(targetPosition);
        float moving = Mathf.Sqrt(((targetPosition.x - transform.position.x) * (targetPosition.x - transform.position.x))+((targetPosition.y - transform.position.y) * (targetPosition.y - transform.position.y)) + ((targetPosition.z - transform.position.z) * (targetPosition.z - transform.position.z)));
        animator.SetFloat("moves", moving);

        if (Vector3.Distance(targetPosition, transform.position) > 1)
        {
            Quaternion rotationToLookAt = Quaternion.LookRotation(targetPosition - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * Time.deltaTime * 10);
            transform.eulerAngles = new Vector3(0, rotationY, 0);
            
            
        }
        else if (Vector3.Angle(enemy.transform.position - transform.position, transform.forward) > 1)
        {
            Quaternion rotationToLookAt = Quaternion.LookRotation(enemy.transform.position - transform.position);
            float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * Time.deltaTime * 10);
            transform.eulerAngles = new Vector3(0, rotationY, 0);
        }

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
