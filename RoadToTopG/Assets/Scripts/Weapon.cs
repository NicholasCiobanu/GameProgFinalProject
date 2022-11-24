

using System.Net.Mail;
using System.Diagnostics.Tracing;
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
    public int magSize;
    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime;
    public bool isReloading = false;
    public Animator animator;
    public Animator zombieAnimator;

    //effects variables
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    [SerializeField]
    private TrailRenderer bulletTrail;




    void Start()
    {
        currentAmmo = magSize;
        mm = FindObjectOfType<MoneyManager>();
    }

    void OnEnable()
    {
        animator.SetBool("Reloading", false);
        isReloading = false;
    }

    void Update()
    {

        GameObject.Find("CurrentMag").GetComponent<UnityEngine.UI.Text>().text = currentAmmo.ToString();
        GameObject.Find("RemainMag").GetComponent<UnityEngine.UI.Text>().text = maxAmmo.ToString();
        if (isReloading)
            return;

        if (currentAmmo == 0 && maxAmmo >= 0 || Input.GetKey(KeyCode.R) && currentAmmo != magSize)
        {
            if (maxAmmo <= 0)
                return;
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
        }
    }

    //will get called every time user shoots
    void Shoot()
    {
        if (currentAmmo <= 0)
            return;
        currentAmmo--;
        muzzleFlash.Play();
        RaycastHit hit;
        audioSource.PlayOneShot(shotSound);
        //if the raycast hits something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, (int)range, 1 << LayerMask.NameToLayer("Default"), QueryTriggerInteraction.Collide))
        {
            GameObject target = hit.transform.gameObject;
            TrailRenderer trail = Instantiate(bulletTrail, new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z), Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            //target.GetComponent<NormalController>().health -= (int)damage;
            Debug.Log(target.name);
            //code for damage receiving and adding money
            if (target != null)
            {

                if (target.name.Contains("Normal")) {
                    target.transform.GetComponent<NormalController>().health -= (int)damage;
                    mm.AddMoney(25);
                }
                else if (target.name.Equals("AndrewTate"))
                    target.transform.GetComponent<AndrewTateController>().health -= (int)damage;
                else if (target.name.Equals("Kanye"))
                    target.transform.GetComponent<KanyeController>().health -= (int)damage;
                else if (target.name.Equals("Sneako"))
                    target.transform.GetComponent<SneakoController>().health -= (int)damage;
                else if (target.name.Equals("TristanTate"))
                    target.transform.GetComponent<TristanController>().health -= (int)damage;
                else if (target.name.Contains("Karen"))
                    target.transform.GetComponent<KarenController>().ReduceHealth((int) damage);



            }
        }
    }



    IEnumerator Reload()
    {
        if (maxAmmo <= 0 && currentAmmo <= 0)
        {
            isReloading = true;
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(0f);
        }
        else if (maxAmmo <= 0)
        {
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(0f);
        }
        else
        {
            isReloading = true;
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(.25f);
            if (maxAmmo > 0)
            {
                if (maxAmmo <= 0)
                    maxAmmo = 0;
                audioSource.PlayOneShot(reloadSound);
                yield return new WaitForSeconds(reloadTime);
                int ammoAdded = magSize - currentAmmo;
                currentAmmo += ammoAdded;
                maxAmmo -= ammoAdded;
                if (maxAmmo < 0)
                    maxAmmo = 0;
                animator.SetBool("Reloading", false);
                isReloading = false;
            }
        }
    }

    IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = trail.transform.position;

        while (time < 1)
        {
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
