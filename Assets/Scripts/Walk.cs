using Unity.VisualScripting;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 5.0f;
    private CharacterController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float gravity = 200f * Time.deltaTime;
        controller.Move(new Vector3(0, -gravity, 0) * Time.deltaTime);
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, horizontal, 0) * Time.deltaTime * turnSpeed);
        if(vertical != 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("walk", true);
            Vector3 move = transform.forward * speed * Time.deltaTime * vertical;
            controller.Move(move);
            
            
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
        }
    }
}
