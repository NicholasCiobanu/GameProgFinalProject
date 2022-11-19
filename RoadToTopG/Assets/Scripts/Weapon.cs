

using System.Linq.Expressions;
using System.Runtime.Versioning;
using System.Reflection;
using System.Runtime;
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    //money controller
    private MoneyManager mm;
    //audio files
    public AudioSource audioSource;
    public AudioClip shotSound;
    public AudioClip reloadSound;
    //shooting variables
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 1f;
    private float nextTimeToFire = 0f;

    //reload and ammunition variables
    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    public bool isReloading = false;
    public Animator animator;
    public Animator zombieAnimator;

    //effects variables
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    [SerializeField]
    private TrailRenderer bulletTrail;


   

    void Start () 
    {
        currentAmmo = maxAmmo;
        mm = FindObjectOfType<MoneyManager>();
    }

    void OnEnable()
    {
        animator.SetBool("Reloading",false);
        isReloading = false;
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
        audioSource.PlayOneShot(shotSound);
        // Detect trigger
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, (int)range,  1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Collide)){
            GameObject target = hit.transform.gameObject;
            TrailRenderer trail = Instantiate(bulletTrail,new Vector3(transform.position.x,transform.position.y + 0.15f,transform.position.z), Quaternion.identity);
            StartCoroutine(SpawnTrail(trail,hit));
            Debug.Log(target);
            //code for damage receiving and adding money
            Debug.Log(target.name);
            if(target != null && target.name == "Normal"){
                Debug.Log("Hit");
                GameObject normal = target;
                while (normal.name != "Normal") {
                    normal = target.transform.parent.gameObject;
                }
                normal.transform.GetComponent<NormalController>().health -= 10;
                mm.AddMoney(15);
            } 
        }
    }

    

    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading",true);
        audioSource.PlayOneShot(reloadSound);
        yield return new WaitForSeconds(reloadTime - .25f);
        animator.SetBool("Reloading",false); 
        yield return new WaitForSeconds(.25f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit){
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while (time < 1) {
            trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = hit.point;
        //destroys impact particle system instantiated
        GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impactGO, 0.5f);
        Destroy(trail.gameObject, trail.time);
    }
}
