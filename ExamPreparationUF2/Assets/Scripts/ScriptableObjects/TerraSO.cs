using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class TerraSO : ScriptableObject
{
    public Sprite terraSeca;
    public Sprite terraRemoguda;
    public Sprite terraRegada;
    public EstatTerra estat_Actual;
    public PlantaSO planta;

}
public enum EstatTerra{
    SECA,REMOGUDA,REGADA
}
