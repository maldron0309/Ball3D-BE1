using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public int itemCount;
    public float jumpPower = 5f;
    private bool isJumping;
    
    private Rigidbody rb;
    private AudioSource audio;
    public GameManager manager;
    
    private void Awake()
    {
        isJumping = false;
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector3(0,jumpPower,0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        rb.AddForce(new Vector3(h,0,v), ForceMode.Impulse);
     }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isJumping = false;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            itemCount++;
            audio.Play();
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "End")
        {
            if (itemCount == manager.totalItemCount)
            {
                SceneManager.LoadScene("Stage" + (manager.stage+1).ToString());
            }
            else
            {
                SceneManager.LoadScene("Stage"+ manager.stage);
            }
            
        }
    }
}
