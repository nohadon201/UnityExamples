using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ClientSO : ScriptableObject
{
    public Vector3 posicioInicial;
    public int Diners;
    public Semilla semillaSeleccionada;
    public List<Semilla> semilles = new List<Semilla>();
    public tools currentTool;
}
public enum tools {
    AIXADA, REGADORA, TISORES
}