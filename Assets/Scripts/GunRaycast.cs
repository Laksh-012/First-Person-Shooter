using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    public float fireRate = 0.2f;
    public float range = 100f;
    public LayerMask hitLayers;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    private float nextFireTime = 0f;
    private AudioSource audioSource;
    private Camera cam;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    void Update()
    {
        if ((Input.GetButtonDown("Fire1") || Input.GetButton("Fire2")) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }

    void Fire()
    {
    
        if (muzzleFlash != null)
            muzzleFlash.Play();

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, range, hitLayers))
        {
            Debug.Log("Hit: " + hit.collider.name);

            if (hitEffect != null)
            {
                GameObject effect = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effect, 1.5f);
            }
        }
    }
}
