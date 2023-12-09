using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;
using TMPro;

public class UIScript : MonoBehaviour
{
    public PlayerSO p1;
    public PlayerSO p2;
    public GameObject p1_go;
    public GameObject p2_go;
    // Start is called before the first frame update
    void Start()
    {
        p1_go.GetComponent<controls>().health += UpdateHealth;
        p2_go.GetComponent<controls>().health += UpdateHealth;
        transform.GetChild(1).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text=p1.nom;
        transform.GetChild(2).GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text=p2.nom;
    }
    public void UpdateHealth()
    {
        Image i = transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
        i.fillAmount = p1.health_bar;

        Image i2 = transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
        i2.fillAmount = p2.health_bar;
    } 
    // Update is called once per frame
    void Update()
    {
        
    }
}
