using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (_movement.Direction != Vector2.zero)
        {
            anim.SetFloat("X", _movement.Direction.x);
            anim.SetFloat("Y", _movement.Direction.y);
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }

}
