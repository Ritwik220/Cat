using Unity.VisualScripting;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private Animator animator;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if(vertical != 0 || horizontal != 0)
        {
            animator.SetBool("walk", true);
            transform.position += transform.forward * speed * Time.deltaTime * vertical;
            transform.Rotate(new Vector3(0, horizontal, 0) * Time.deltaTime * turnSpeed);
        }
        else
        {
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
        }
    }
}
