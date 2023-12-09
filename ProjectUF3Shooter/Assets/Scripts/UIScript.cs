using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Weapon weaponOfPlayer;
    // Start is called before the first frame update
    void Awake()
    {
        weaponOfPlayer.DisplayEvent += DisplayOrNotTheText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayOrNotTheText()
    {
        if (transform.GetChild(1).gameObject.activeSelf)
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(true);   
        }
    }
    public void changeTheText(string text, Color color)
    {
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().color = color;
    }
}
