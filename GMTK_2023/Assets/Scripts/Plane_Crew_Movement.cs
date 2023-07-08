using UnityEngine;

public class Plane_Crew_Movement : MonoBehaviour
{
    private Plane plane;
    public float speed = 10;
    private Animator animator;
    public bool[] keypress;
    private void Start()
    {
        plane = GameObject.FindAnyObjectByType<Plane>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!plane.is_pilot)
        {
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Walking", true);
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Walking", true);
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                transform.position = new Vector2(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y);
            }
            else
            {
                animator.SetBool("Walking", false);
            }
        }
    }
}
