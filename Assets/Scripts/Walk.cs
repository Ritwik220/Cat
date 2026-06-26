using Unity.VisualScripting;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float normalSpeed = 3.0f;
    [SerializeField] float sprintSpeed = 8.0f;
    [SerializeField] float turnSpeed = 5.0f;
    [SerializeField] Transform desiredOrientation;
    private CharacterController controller;
    private AudioSource audioSource;
    private float idleTime = 0.0f;
    private float sittingTime = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        float gravity = 200f * Time.deltaTime;
        controller.Move(new Vector3(0, -gravity, 0) * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, horizontal * vertical, 0) * Time.deltaTime * turnSpeed);
        if(vertical != 0)
        {
            float speed = normalSpeed;
            idleTime = 0;
            sittingTime = 0;
            animator.SetBool("sitting", false);
            animator.SetBool("sit", false);
            animator.SetBool("meow", false);
            animator.SetBool("idle", false);
            if(Input.GetAxis("run") != 0)
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", true);
                speed = sprintSpeed;
            }
            else {
                animator.SetBool("run", false);
                animator.SetBool("walk", true);
            }
            if(transform.eulerAngles != desiredOrientation.eulerAngles){
                Quaternion targetRotation =
                Quaternion.Euler(
                    0,
                    desiredOrientation.eulerAngles.y,
                    0);

                transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                turnSpeed * Time.deltaTime);
            }
            Vector3 move = transform.forward * speed * Time.deltaTime * vertical;
            controller.Move(move);
               
        }
        else
        {
            idleTime += Time.deltaTime;
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
            if(idleTime > 5.0f)
            {
                sittingTime += Time.deltaTime;
                animator.SetBool("idle", false);
                animator.SetBool("sit", true);
                if(sittingTime > 2.0f)
                {
                    animator.SetBool("sit", false);
                    animator.SetBool("sitting", true);
                }
            }
        }
        if(Input.GetButtonDown("Submit"))
        {
            audioSource.Play();
            
        }
    }
}
