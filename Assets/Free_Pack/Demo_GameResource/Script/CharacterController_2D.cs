using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController_2D : MonoBehaviour {

    Animator m_Animator;

    private float h = 0;
    private float v = 0;

    public float MoveSpeed = 40;

    public bool Once_Attack = false;


    // Use this for initialization
    void Start () {
        m_Animator = transform.Find("BURLY-MAN_1_swordsman_model").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Once_Attack = false;
            Debug.Log("Lclick");
            m_Animator.SetTrigger("Attack");


        }

        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Once_Attack = false;
            Debug.Log("Rclick");
            m_Animator.SetTrigger("Attack2");
        }


        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
          
            Debug.Log("1");
            m_Animator.Play("Hit");




        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("2");
            m_Animator.Play("Die");


        }


        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") || m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Die")||
            m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")|| m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            return;

        Move_Fuc();


        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
       


        m_Animator.SetFloat("MoveSpeed", Mathf.Abs(h )+Mathf.Abs (v));

 
    }

    // character Move Function
    void Move_Fuc()
    {
        if (Input.GetKey(KeyCode.A))
        {
          //  Debug.Log("Left");
            //m_rigidbody.AddForce(Vector2.left * MoveSpeed);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
          //  Debug.Log("Right");
            //m_rigidbody.AddForce(Vector2.right * MoveSpeed);
            transform.localScale = new Vector3(-0.5f,0.5f,0.5f);
        }

        if (Input.GetKey(KeyCode.W))
        {
           // Debug.Log("up");
            //m_rigidbody.AddForce(Vector2.up * MoveSpeed);
          
        }
        else if (Input.GetKey(KeyCode.S))
        {
           // Debug.Log("Down");
            //m_rigidbody.AddForce(Vector2.down * MoveSpeed);
          
            
        }

    } 
    //   Sword,Dagger,Spear,Punch,Bow,Gun,Grenade


  

  
}
