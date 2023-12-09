using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        this.tag = "Projectil_Nau";
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > this.transform.parent.position.y + 10)
        {
            this.gameObject.SetActive(false);
        }
    }
}
