using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public UIData data; 
    public GameObject go;
    // Start is called before the first frame update
    void Awake()
    {
        Escut es = go.GetComponent<Escut>();
        es.escutResta += reduirVida;
        StartCoroutine(countdowning());
    }
    IEnumerator countdowning()
    {
        while(this.data.countdown > 0) {
            yield return new WaitForSeconds(1);
            this.data.countdown--;
        }
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text="Laser de la mort en: "+data.countdown;
        transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = "VidaEscut: " + data.health_escut;
        if (data.health_escut == 0)
        {
            SceneManager.LoadScene("sceneb");
        }
    }
    public void reduirVida()
    {
        this.data.health_escut--;
    }
    public void win()
    {
        SceneManager.LoadScene("win");
    }
}
