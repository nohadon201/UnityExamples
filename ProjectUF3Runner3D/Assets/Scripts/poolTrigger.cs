using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class poolTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;
    [SerializeField]
    [DefaultValue(DirectionMisil.ATRÁS)]
    private DirectionMisil direction;
    private bool triggered;
    private bool reset;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(this.transform.position, this.transform.forward*50, Color.magenta);
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, 50f))
        {
            if (hitInfo.transform.name == "Sanic" && !triggered)
            {
                triggered = true;
                this.coroutine=StartCoroutine(startSpawn());

            }
            else if(hitInfo.transform.name == "Sanic")
            {
                reset= true;    
            }
        }

    }
    IEnumerator startSpawn()
    {
        int cont = 0;   
        while (cont<=20)
        {  
            for (int a = 0; a < transform.childCount; a++)
            {
                if (!transform.GetChild(a).gameObject.activeSelf)
                {
                    transform.GetChild(a).gameObject.SetActive(true);
                    transform.GetChild(a).transform.position = Target.transform.position;
                    switch (direction)
                    {
                        case DirectionMisil.IZQUIERDA: transform.GetChild(a).GetComponent<Rigidbody>().AddForce(new Vector3(-5000, 0, 0)); break;
                        case DirectionMisil.DERECHA: transform.GetChild(a).GetComponent<Rigidbody>().AddForce(new Vector3(5000, 0, 0)); break;
                        case DirectionMisil.ATRÁS: transform.GetChild(a).GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -5000)); break;
                        case DirectionMisil.ADELANTE: transform.GetChild(a).GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 5000)); break;
                    }
                    break;
                }
            }
            yield return new WaitForSeconds(0.7f);
            cont++;
            if (reset)
            {
                reset= false;
                cont = 0;
            }
        }
        triggered= false;
    }
}
public enum DirectionMisil
{
    IZQUIERDA,DERECHA,ATRÁS,ADELANTE
}