using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>().x > 0f)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", true);
        }
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
}
