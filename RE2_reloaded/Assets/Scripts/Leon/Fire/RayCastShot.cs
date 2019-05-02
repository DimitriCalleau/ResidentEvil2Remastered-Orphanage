using UnityEngine;

public class RayCastShot : MonoBehaviour
{
    public float damage = 0f;
    public float range = 0f;
    public float impactForce = 60f;
    public float fireRate = 15f;


    public Camera aimCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactParticle;


    private float nextTimeToFire = 0f;


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();


        RaycastHit hit;
        if (Physics.Raycast(aimCam.transform.position, aimCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            TargetShoot target = hit.transform.GetComponent<TargetShoot>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 2f);
        }

    }
}
