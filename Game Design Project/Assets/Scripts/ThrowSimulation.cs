using UnityEngine;
using System.Collections;

public class ThrowSimulation : MonoBehaviour
{

    //public GameObject gameLogic;
    Transform Target; 
    float firingAngle = 45.0f;
    float gravity = 9.8f;


    //oggetto lanciato
    Transform Projectile;
    Transform startingPoint;

    /*
    void Awake()
    {
        startingPoint = transform;
        Target = gameLogic.GetComponent<Logic_Earth>().ThrowTarget.transform;
    }

    void Start()
    {
        Target = gameLogic.GetComponent<Logic_Earth>().ThrowTarget.transform;
        StartCoroutine(SimulateProjectile());
    }
    */

    public void Throw(Transform projectile,  Transform from, Transform to, float firingAngle)
    {
        this.Projectile = projectile;
        this.startingPoint = from;
        this.Target = to;
        this.firingAngle = firingAngle;
        StartCoroutine(SimulateProjectile());
    }

    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = startingPoint.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}