
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    //shooting variables
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    private float nextTimeToFire = 0f;

    //reload and ammunition variables
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public Animator animator;

    //effects variables
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;


    void Start () 
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading",false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + (1f/fireRate);
            Shoot();
        }
    }

    //will get called every time user shoots
    void Shoot(){
        currentAmmo--;
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

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading",true);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading",false); 
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
