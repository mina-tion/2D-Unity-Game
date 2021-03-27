using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalkRight", true);
        }
        else
        {
            anim.SetBool("isWalkRight", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalkLeft", true);
        }
        else
        {
            anim.SetBool("isWalkLeft", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalkUp", true);
        }
        else
        {
            anim.SetBool("isWalkUp", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalkDown", true);
        }
        else
        {
            anim.SetBool("isWalkDown", false);
        }
    }
}
