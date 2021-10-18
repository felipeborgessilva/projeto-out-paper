using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public float jumpForce;
    private float movement;

    private float horizontal;
    private float vertical;


    public bool isLookingLeft;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        float speedY = rig.velocity.y;

        if(horizontal > 0 && isLookingLeft) 
        {
            Flip();
        } else if(horizontal < 0 && !isLookingLeft) 
        {
            Flip();
        }


        if (horizontal != 0)
        {
            anim.SetBool("walking", true);
        } else {
            anim.SetBool("walking", false);
        }
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, jumpForce));
        }
        rig.velocity = new Vector2(horizontal * speed, speedY);

    }

    void Flip() {
        anim.SetTrigger("flipping");
        isLookingLeft = !isLookingLeft;
        float x = transform.localScale.x * -1; 
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate() {

    }


}
