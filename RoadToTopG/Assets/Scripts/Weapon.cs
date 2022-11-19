
using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    //money controller
    private MoneyManager mm;
    //audio files
    public AudioSource audioSource;
    public AudioClip shotSound;
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
        // audioSource.PlayOneShot(shotSound);
        //if the raycast hits something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            GameObject target = hit.transform.gameObject;
            TrailRenderer trail = Instantiate(bulletTrail,new Vector3(transform.position.x,transform.position.y + 0.15f,transform.position.z), Quaternion.identity);
            StartCoroutine(SpawnTrail(trail,hit));
            //code for damage receiving and adding money
            if(target != null){

                if (target.name.Equals("Normal"))
                    target.transform.GetComponent<NormalController>().health -= 10;
                else if (target.name.Equals("AndrewTate"))
                    target.transform.GetComponent<AndrewTateController>().health -= 5;
                else if (target.name.Equals("Kanye"))
                    target.transform.GetComponent<KanyeController>().health -= 5;
                else if (target.name.Equals("Sneako"))
                    target.transform.GetComponent<SneakoController>().health -= 5;
                else if (target.name.Equals("TristanTate"))
                    target.transform.GetComponent<TristanController>().health -= 5;

                

            } 
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
