
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 2f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + (1f/fireRate);
            Shoot();
        }
    }

    //will get called every time user shoots
    void Shoot(){
        //muzzle flash particle effect
        muzzleFlash.Play();
        RaycastHit hit;
        
        //if the raycast hits something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);
        
        // Target target = hit.transform.GetComponent<Target>(); //code for damage receiving
        // if(target != null){
        //     target.TakeDamage(damage);
        // }

        //destroys impact particle system instantiated
        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 0.5f);

        }
    }
}
