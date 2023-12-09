using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridInventory : MonoBehaviour
{
    public List<Items> inv = new List<Items>();
    public Weapon p;
    public Items b;
    public Items f;
    private int arrowpos = 0;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inv.Add(p);
            addGrid(p);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            inv.Add(b);
            addGrid(b);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            inv.Add(f);
            addGrid(f);
        }

        controlFlecha();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(this.transform.GetChild(arrowpos).gameObject);
            inv.RemoveAt(arrowpos);
        }

    }

    private void controlFlecha()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            arrowpos--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            arrowpos++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arrowpos -= 5;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arrowpos += 5;
        }

        int len = inv.Count;
        if (arrowpos < 0) arrowpos = 0;
        if (arrowpos >= len) arrowpos = len - 1;
        arrow.transform.position = this.transform.GetChild(arrowpos).position;
    }

    private void addGrid(Items i)
    {
        GameObject go = new GameObject();
        go.AddComponent<Image>();
        go.GetComponent<Image>().sprite = i.sprite;
        go.transform.name = i.name;
        go.transform.parent = this.gameObject.transform;
    }

}
