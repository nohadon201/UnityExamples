using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManagerScript : MonoBehaviour
{
    public ManagerSO m_data;
    public List<GameObject> Players = new List<GameObject>();
    void Awake()
    {
        GameObject UI = GameObject.Find("UI");

        GameObject p1 = Players[this.m_data.P1];
        GameObject p2 = Players[this.m_data.P2];
        
        p1.GetComponent<controls>().enemy = p2.GetComponent<controls>().self;
        p2.GetComponent<controls>().enemy = p1.GetComponent<controls>().self;
        
        p1.transform.position = new Vector3(-4.21f, 0.46f, 0);
        p2.transform.position = new Vector3(-3.06f, 0.46f, 0);
        
        p1.GetComponent<controls>().enemy = p2.GetComponent<controls>().self;
        p2.GetComponent<controls>().enemy = p1.GetComponent<controls>().self;
        
        p1.SetActive(true);
        p2.SetActive(true);

        p1.GetComponent<controls>().self.health_bar = 1;
        p2.GetComponent<controls>().self.health_bar = 1;

        GameObject InstanciedPlayer1 = Instantiate(p1);
        GameObject InstanciedPlayer2 = Instantiate(p2);
        
        UI.GetComponent<UIScript>().p1 = InstanciedPlayer1.GetComponent<controls>().self;
        UI.GetComponent<UIScript>().p2 = InstanciedPlayer2.GetComponent<controls>().self;
        
        UI.GetComponent<UIScript>().p1_go = InstanciedPlayer1;
        UI.GetComponent<UIScript>().p2_go = InstanciedPlayer2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
