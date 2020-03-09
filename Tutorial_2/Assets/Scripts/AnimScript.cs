using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{

    Animator anim;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rd2d;
    private void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (mySpriteRenderer != null)
                mySpriteRenderer.flipX = false;
            anim.SetInteger("Idle", 1);
        }

        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (mySpriteRenderer != null)
                mySpriteRenderer.flipX = true;
            anim.SetInteger("Idle", 1);
        }
       

        if (Input.GetKeyDown(KeyCode.R))
        {
            
            anim.SetInteger("Idle", 2);
        }



    }
    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("Idle", 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("Idle", 0);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetInteger("Idle", 0);
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            anim.SetInteger("Idle", 0);
        }
    }
}
