using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public GiliusSO dataGilius;
    public EnemySO OwnData;
    public StateEnemy currentState;
    void Awake()
    {
        OwnData.current_HP = 5;
        currentState = StateEnemy.NONE;
    }

    // Update is called once per frame
    void Update()
    {

        if (dataGilius != null && dataGilius.transform.position.x < this.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 180);

        }
        else
        {
            transform.rotation = Quaternion.identity;

        }



        if (this.currentState == StateEnemy.AGRO)
        {
            Vector3 finalPoint = new Vector3(dataGilius.transform.position.x, dataGilius.transform.position.y, this.transform.position.z);
            Vector3 direction = finalPoint - this.transform.position;
            direction.Normalize();
            GetComponent<Rigidbody2D>().velocity = direction;
        }
        else if (this.currentState == StateEnemy.NONE)
        {
            GetComponent<Rigidbody2D>().velocity = this.transform.right * 1.1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurboxGilius")
        {
            if (collision.gameObject.transform.parent.GetComponent<CharacterMovement>().currentState == State.SPACE)
            {
                this.OwnData.current_HP--;
                if (this.OwnData.current_HP <= 0)
                {
                    this.gameObject.SetActive(false);
                    this.OwnData.current_HP = 5;
                }
            }
            else if (collision.gameObject.transform.parent.GetComponent<CharacterMovement>().currentState == State.DOUBLE_SPACE)
            {
                this.OwnData.current_HP -= 2;
                if (this.OwnData.current_HP <= 0)
                {
                    this.gameObject.SetActive(false);
                    this.OwnData.current_HP = 5;
                }
            }
            else
            {
                this.OwnData.current_HP -= 3;
                if (this.OwnData.current_HP <= 0)
                {
                    this.gameObject.SetActive(false);
                    this.OwnData.current_HP = 5;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HitboxGilius")
        {
            StartCoroutine(attacking());
        }
    }
    IEnumerator attacking()
    {
        this.currentState = StateEnemy.ATTACK;
        GetComponent<Animator>().Play("New Animation");
        yield return new WaitForSeconds(1f);
        this.currentState = StateEnemy.AGRO;
    }
}

public enum StateEnemy
{
    NONE, AGRO, ATTACK
}
