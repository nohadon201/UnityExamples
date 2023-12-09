using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class controllsScript : MonoBehaviour
{
    
    public  bool wallrun_z;
    private Vector3 initPos;
    public bool wallrun_x;
    [SerializeField]
    private int vidas;
    [SerializeField]
    [DefaultValue(5)]
    private int Speed;
    // Start is called before the first frame update
    void Awake()
    {
        initPos = new Vector3(7.68f, 3.21f, 5f);
        vidas = 3;

        this.wallrun_z = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            vidas--;
            if(vidas==0)
            {
                SceneManager.LoadScene("GameOver");
            }
            this.transform.position = initPos;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        }
        
        if (wallrun_z)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<Rigidbody>().AddForce(transform.up*1000);
            }
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().velocity = (this.transform.forward+(-this.transform.up))*Speed;

            }else if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().velocity = (-this.transform.forward + (-this.transform.up)) * Speed;
            }
            else if (Input.GetKey("q"))
            {
                this.GetComponent<Rigidbody>().velocity = (-this.transform.right + (-this.transform.up)) * Speed;
            }
            else if (Input.GetKey("e"))
            {
                this.GetComponent<Rigidbody>().velocity = (this.transform.right + (-this.transform.up)) * Speed;
            }
            else
            {
                this.GetComponent<Rigidbody>().velocity = -this.transform.up;
            }
            if (Input.GetKey("d"))
            {
                this.transform.Rotate(new Vector3(0, 1, 0) * 1);
            }
            if (Input.GetKey("a"))
            {
                this.transform.Rotate(new Vector3(0, -1, 0) * 1);
            }


        }
        else
        {

            if (Input.GetKey(KeyCode.W))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(this.transform.forward.x * Speed, this.GetComponent<Rigidbody>().velocity.y, transform.forward.z * Speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(-this.transform.forward.x * Speed, this.GetComponent<Rigidbody>().velocity.y, -transform.forward.z * Speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Rotate(new Vector3(0, -1, 0) * 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Rotate(new Vector3(0, 1, 0) * 1);
            }
            if (Input.GetKey(KeyCode.Q)) 
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(-this.transform.right.x * Speed, this.GetComponent<Rigidbody>().velocity.y, -transform.right.z * Speed);
            }
            if (Input.GetKey(KeyCode.E))
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(this.transform.right.x * Speed, this.GetComponent<Rigidbody>().velocity.y, transform.right.z * Speed);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.GetComponent<Rigidbody>().velocity = this.transform.up * Speed;
            }
        }
        
    }
    public void Rotation(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 v2 = context.ReadValue<Vector2>();
            if (!wallrun_z)
            {
                print("aaa");
                if (v2.x > 0)
                {
                    transform.GetChild(0).transform.Rotate(0, 1, 0);
                }
                else if (v2.x < 0)
                {
                    transform.GetChild(0).transform.Rotate(0, -1, 0);
                }
                else
                {
                    transform.GetChild(0).transform.Rotate(0, 0, 0);
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "wallrun_z")
        {
            this.wallrun_z = true;
            this.transform.Rotate(new Vector3(-90, 0, 0));
            this.GetComponent<Rigidbody>().useGravity = false;
        } else if (collision.gameObject.transform.tag == "sphere")
        {
            print("aaaa");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "wallrun_z")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0) * 3;
            this.wallrun_z = false;
            this.transform.rotation= new Quaternion(0,0,0,0);
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
