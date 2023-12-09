using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraScript : MonoBehaviour
{
    public TerraSO data;
    private int duradaActualCreixer;
    void Awake()
    {
        data.estat_Actual = EstatTerra.SECA;
        data.planta = null;
        this.GetComponent<SpriteRenderer>().sprite = data.terraSeca;
        this.duradaActualCreixer = 0;
    }

    public void onTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "clintTool")
        {
            ClientSO dataClint = collision.gameObject.transform.parent.GetComponent<Clint>().data;
            if (this.data.estat_Actual == EstatTerra.SECA && dataClint.currentTool == tools.AIXADA)
            {
                this.data.estat_Actual = EstatTerra.REMOGUDA;
                this.GetComponent<SpriteRenderer>().sprite = data.terraRemoguda;
            }
            else if (this.data.estat_Actual == EstatTerra.REMOGUDA && dataClint.currentTool == tools.REGADORA)
            {
                this.data.estat_Actual = EstatTerra.REGADA;
                this.GetComponent<SpriteRenderer>().sprite = data.terraRegada;
            }
            else if (dataClint.currentTool == tools.TISORES && this.data.planta != null)
            {
                if (this.duradaActualCreixer == this.data.planta.duradaMaxCreixer)
                {
                    dataClint.Diners += this.data.planta.preu;
                    this.data.planta = null;
                    this.data.estat_Actual = EstatTerra.SECA;
                    this.GetComponent<SpriteRenderer>().sprite = data.terraSeca;
                    this.duradaActualCreixer = 0;
                }
            }
        }
        else if (collision.gameObject.tag == "clintSemilla")
        {
            ClientSO dataClint = collision.gameObject.transform.parent.GetComponent<Clint>().data;
            if (dataClint.semillaSeleccionada != null && dataClint.semillaSeleccionada.quantitat > 0 && this.data.planta == null && (this.data.estat_Actual == EstatTerra.REMOGUDA || this.data.estat_Actual == EstatTerra.REGADA))
            {
                this.data.planta = dataClint.semillaSeleccionada.planta;
                dataClint.semillaSeleccionada.quantitat--;
            }
        }
    }
    public void CanviDia()
    {

        if (this.data.planta != null && this.data.estat_Actual == EstatTerra.REGADA)
        {
            this.duradaActualCreixer++;
        }
        if (this.data.estat_Actual == EstatTerra.REGADA)
        {
            this.data.estat_Actual = EstatTerra.REMOGUDA;
            this.GetComponent<SpriteRenderer>().sprite = data.terraRemoguda;
        }
        else if (this.data.estat_Actual == EstatTerra.REMOGUDA && this.data.planta == null)
        {
            this.data.estat_Actual = EstatTerra.SECA;
            this.GetComponent<SpriteRenderer>().sprite = data.terraSeca;
        }


    }
    void Update()
    {

    }
}
