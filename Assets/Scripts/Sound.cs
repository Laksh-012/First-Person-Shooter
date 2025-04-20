using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerAudioController : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip walkClip;
    public AudioClip jumpClip;
    public AudioClip fireClip;

    [Header("Settings")]
    public float walkStepRate = 0.4f;

    private AudioSource audioSource;
    private CharacterController controller;
    private float walkTimer = 0f;
    private bool isWalking;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleWalking();
        HandleJump();
        HandleFire();
    }

    void HandleWalking()
    {
        bool grounded = controller.isGrounded;
        float speed = controller.velocity.magnitude;

        if (grounded && speed > 0.1f)
        {
            isWalking = true;
            walkTimer -= Time.deltaTime;
            if (walkTimer <= 0f)
            {
                audioSource.PlayOneShot(walkClip);
                walkTimer = walkStepRate;
            }
        }
        else
        {
            isWalking = false;
            walkTimer = 0f;
        }
    }

    void HandleJump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }

    void HandleFire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(fireClip);
        }

        if (Input.GetButton("Fire1"))
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(fireClip);
        }
        
    }
}
