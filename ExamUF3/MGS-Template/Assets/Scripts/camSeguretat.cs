using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camSeguretat : MonoBehaviour
{
    public OnDetectionPlayer ge;
    private bool derecha;
    private Vector3 currentEulerAngles;
    // Start is called before the first frame update
    void Start()
    {
        derecha= false;
        currentEulerAngles = transform.eulerAngles;
        StartCoroutine(CameraMovement());
        transform.GetChild(1).gameObject.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(1).transform.forward=-this.transform.up;
        if (derecha)
        {
            currentEulerAngles += new Vector3(0, 2, 0) * Time.deltaTime * 3;
        }
        else
        {
            currentEulerAngles += new Vector3(0, -2, 0) * Time.deltaTime * 3;
        }
        transform.eulerAngles = currentEulerAngles;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("camSeguretat: " + other.name);
        if (other.tag == "espia")
        {
            print("espia detectat");

            ge.Raise(other.transform);
        }
    }
    IEnumerator CameraMovement()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            if(derecha)
            {
                derecha= false;
            }
            else
            {
                derecha= true;
            }
            yield return new WaitForSeconds(6f);
        }
    }
}

