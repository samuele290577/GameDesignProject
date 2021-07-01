using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    float lifespan;
    GameObject projectile;

    public GameObject projectilePrefab;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(Vector3 to)
    {
        projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = transform.position;
        projectile.transform.rotation = transform.rotation;
        Vector3 direction = (to - transform.position).normalized;
        Vector3 vel = new Vector3(speed*direction.x, 0, speed*direction.z);
        projectile.GetComponent<Rigidbody>().AddForce(vel, ForceMode.Impulse);
        lifespan = Vector3.Distance(transform.position, to) / speed;
        StartCoroutine("Life");
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(lifespan);
        //Qui deve o colpire o comunque fare booooom

        Destroy(projectile);
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }

}
