using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class controls : MonoBehaviour
{
    private Coroutine cooldown_Combo;
    private Animator animator;
    private bool mov_der;
    private bool mov_iz;
    private bool attack;
    private bool derecha;
    private int vida;
    private int jump_count;
    private bool jump;
    private bool block;
    private StatusCombo status;

    public PlayerSO self;
    public PlayerSO enemy;
    public delegate void HealthChanger();
    public HealthChanger health;

    void Awake()
    {
        this.status = StatusCombo.NONE;
        jump = false;
        vida = this.self.Vida_Max;
        attack = true;
        animator=this.GetComponent<Animator>();
        self.position = this.transform;
        block = false;  

    }

    void Update()
    {
        
        self.position = this.transform;
        if (this.status == StatusCombo.NONE)
        {
            if (mov_der)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(9, GetComponent<Rigidbody2D>().velocity.y);
                this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            }
            else if (mov_iz)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-9, GetComponent<Rigidbody2D>().velocity.y);
                this.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
                
                this.animator.SetTrigger("stop");
                if (enemy.position.position.x > this.transform.position.x)
                {
                    this.derecha = true;
                    this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                }
                else
                {
                    this.derecha = false;
                    this.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
                }
            }
        }
        
        
    }
    public void aserPupa()
    {
        if (this.derecha)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, this.GetComponent<Rigidbody2D>().velocity.y));
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, this.GetComponent<Rigidbody2D>().velocity.y));
        }
        this.vida-=1;
        this.self.health_bar =(float) this.vida / this.self.Vida_Max;
        health?.Invoke();
        if (vida <= 0)
        {
            Destroy(this.gameObject);

        }
        
    }
   
    public void Startcombo()
    {
        attack=false;
    }
    public void FinishCombo()
    {
        attack = true;

    }
    public void Movement(InputAction.CallbackContext context)
    {
       
            if (context.ReadValue<Vector2>().x < 0)
            {
            if (this.status == StatusCombo.NONE)
            {
                this.transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
                if (!jump)
                {
                    animator.Play("Run");
                }
            }
                
                this.mov_der = false;
                this.mov_iz = true;
            }
            else if (context.ReadValue<Vector2>().x > 0)
            {
            if (this.status == StatusCombo.NONE)
            {
                if (!jump)
                {
                    animator.Play("Run");
                }
            }
            this.mov_der = true;
                this.mov_iz = false;
            }
            else
            {
                this.mov_der = false;
                this.mov_iz = false;

            }

        
    }
    public void Bloqueig(InputAction.CallbackContext context)
    {
        if(!jump && status==StatusCombo.NONE && !mov_der && !mov_iz)
        {
            if (context.started)
            {
                block = true;
                transform.GetChild(2).gameObject.SetActive(block);
            }
            if (context.performed || context.canceled)
            {
                block = false;
                transform.GetChild(2).gameObject.SetActive(block);
            }
        }
        

    }
    public void AttackUpper1(InputAction.CallbackContext context)
    {
        if (context.performed && !jump && !block)
        {
            animator.Play("UpperAttack1");
            this.status = StatusCombo.A;
            cooldown_Combo = StartCoroutine(ComboCoolDown(1.01f));
        }
    }
    public void AttackUpper2(InputAction.CallbackContext context)
    {
        if (context.performed && !jump && !block)
        {

            this.status = StatusCombo.AA;
            animator.Play("UpperAttack2");
            cooldown_Combo = StartCoroutine(ComboCoolDown(1.15f));
        }
    }
    public void AttackNormal1(InputAction.CallbackContext context)
    {
        if (context.performed && !jump && !block)
        {
            this.status = StatusCombo.B;
            this.animator.Play("NormalAttack1");
            cooldown_Combo = StartCoroutine(ComboCoolDown(0.21f));
        }
    }
    public void AttackNormal2(InputAction.CallbackContext context)
    {
        if (context.performed && !jump && !block)
        {

            this.status = StatusCombo.BB;
            this.animator.Play("NormalAttack2");
            cooldown_Combo = StartCoroutine(ComboCoolDown(0.22f));
        }
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (!jump || jump_count==0) && status==StatusCombo.NONE && !block)
        {
            jump_count = jump ? 1 : 0;
            jump =true;    
            GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, 400));
            animator.SetTrigger("jump");
        }
    }

    internal void setJump(bool v)
    {
        jump=v;
        jump_count = 0;
        if (this.GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            this.animator.Play("iddle");
        }else 
        {
            this.animator.Play("Run");
        }
    }

    
public IEnumerator ComboCoolDown(float f) 
{
   yield return new WaitForSeconds(f);
   status = StatusCombo.NONE;
}

}
public enum StatusCombo
{
    NONE, A, B,AA,BB,HURT
}