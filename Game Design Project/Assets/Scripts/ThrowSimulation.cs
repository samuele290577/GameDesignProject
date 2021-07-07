using UnityEngine;
using System.Collections;

public class ThrowSimulation : MonoBehaviour
{

    public string team;

    Vector3 Target;

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

    public void Throw(Vector3 to, float firingAngle)
    {
        this.Target = to;
        //StartCoroutine(SimulateProjectile());

        float target_Distance = Vector3.Distance(transform.position, Target);
        Vector3 direction = (Target - (transform.position + Vector3.zero)).normalized; // eventuale offset su Vector3.zero

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / (Physics.gravity.y * -1));

        // Extract the X Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float correttivo = .5f * target_Distance / Vx; //tentativo di valore correttivo della velocità
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad) - correttivo;

        Vector3 vel = new Vector3(Vx * direction.x, Vy, Vx * direction.z);

        this.gameObject.GetComponent<Rigidbody>().AddForce(vel, ForceMode.Impulse);
        //this.gameObject.GetComponent<Rigidbody>().AddTorque(torque);
    }

    /*
    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(0.2f);
        
        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = startingPoint.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }

        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    */

    private void Start()
    {
        GameObject playerToIgnore;
        if (team == "Plants") playerToIgnore = GameObject.FindGameObjectWithTag("Plant_Player");
        else playerToIgnore = GameObject.FindGameObjectWithTag("Human_Player");
        Physics.IgnoreCollision(playerToIgnore.GetComponent<BoxCollider>(), this.GetComponent<CapsuleCollider>());
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain") Destroy(this.gameObject);
    }
}