using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D m_RigidBody;
    [SerializeField]
    float m_Speed = 4;
    public State currentState;
    private Coroutine resetCoroutine;
    public GiliusSO data;
    void Awake()
    {
        this.data.current_HP = this.data.Max_HP;
        this.data.current_vides=this.data.Max_vides;    
        currentState = State.NONE;
        m_RigidBody = GetComponent<Rigidbody2D>();
        this.data.transform = this.transform;
    }

    
    void Update()
    {
        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movement += transform.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        m_RigidBody.velocity = movement.normalized * m_Speed;

        //rotem segons on estem anant
        if(movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.up*180);
        }
        else if(movement.x > 0)
        {
            transform.rotation = Quaternion.identity;
        }
    }
    public void Attack1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }
            if(this.currentState== State.NONE)
            {
                this.currentState = State.SPACE;
                GetComponent<Animator>().Play("Attack1");
                resetCoroutine = StartCoroutine(reset(0.5f));
            }else if(this.currentState== State.SPACE) {
                this.currentState = State.DOUBLE_SPACE;
                GetComponent<Animator>().Play("Attack2");
                resetCoroutine = StartCoroutine(reset(1.5f));
            }
            else
            {
                this.currentState = State.NONE;
                GetComponent<Animator>().Play("Attack3");
                this.currentState = State.NONE;
            }
        }
    }
    IEnumerator reset(float a)
    {
        yield return new WaitForSeconds(a);
        currentState = State.NONE;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TriggerArea")
        {
            collision.gameObject.transform.parent.GetComponent<enemyScript>().currentState = StateEnemy.AGRO;
        }
    }
}
public enum State
{
    NONE,SPACE,DOUBLE_SPACE
}
