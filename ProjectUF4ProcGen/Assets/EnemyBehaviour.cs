using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{
    public int Seed;
    public int OffsetX;
    public int OffsetY;
    public int Frequency;
    public Rigidbody2D Rigidbody;
    public float perlinValue;
    private float velocity;
    void Awake()
    {
        velocity = 1f;
        Rigidbody = GetComponent<Rigidbody2D>();    
        EnemyRandomInfo enemyRandomInfo = Resources.Load<EnemyRandomInfo>("ScriptableObject/EnemyRandomInfo 1");
        RandomEnemyObject REO1 = enemyRandomInfo.list[(int)Random.Range(0, enemyRandomInfo.list.Count - 1)];
        RandomEnemyObject REO2 = enemyRandomInfo.list[(int)Random.Range(0, enemyRandomInfo.list.Count - 1)];
        RandomEnemyObject REO3 = enemyRandomInfo.list[(int)Random.Range(0, enemyRandomInfo.list.Count - 1)];

        Seed = REO1.Seed[(int)Random.Range(0, REO1.Seed.Count - 1)];
        OffsetX = REO2.OffsetX[(int)Random.Range(0, REO2.OffsetX.Count - 1)];
        OffsetY = REO2.OffsetY[(int)Random.Range(0, REO2.OffsetY.Count - 1)];
        Frequency = REO3.Frequency[(int)Random.Range(0, REO3.Frequency.Count - 1)];
        StartCoroutine(changeAngle());
    }

    
    void Update()
    {
        Rigidbody.velocity = transform.up * velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Rock":
                collision.gameObject.SetActive(false);
                break;
            case "Water":
                collision.gameObject.SetActive(false);
                StartCoroutine(stune());
                break;
            case "Player":
                SceneManager.LoadScene("GameOver");
                break;
        }
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, 0.9f))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red, 3f);
            if(hit.transform.tag == "Rock")
            {
                hit.transform.gameObject.SetActive(false);  
            }else if(hit.transform.tag == "Water")
            {
                hit.transform.gameObject.SetActive(false);
                StartCoroutine(stune());
            }else if(hit.transform.tag == "Player")
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position +(transform.up*0.9f), Color.red, 3f);
        }
    }
    private IEnumerator stune()
    {
        velocity = 0f;
        yield return new WaitForSeconds(3f);
        velocity = 1f;
    }
    private IEnumerator changeAngle()
    {
        while(true)
        {
            perlinValue = -1+(2*Mathf.PerlinNoise((transform.position.x + Seed + OffsetX) / Frequency, (transform.position.y + Seed + OffsetY) / Frequency));
            
            transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x,transform.rotation.y,perlinValue,transform.rotation.w), 0.3f);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
