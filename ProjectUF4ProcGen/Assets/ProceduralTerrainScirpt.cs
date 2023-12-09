using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralTerrainScirpt : MonoBehaviour
{
    [Header("TerrainVariables")]
    [SerializeField] private GameObject blocTerra;
    [SerializeField] private GameObject blocAigua;
    [SerializeField] private int Width;
    [SerializeField] private int Height;
    [SerializeField] private int Seed;
    [SerializeField] private int Frequency;
    [SerializeField] private int OffsetX;
    [SerializeField] private int OffsetY;
    [Header("")]
    [Header("Enemies SpawnPoints")]
    [SerializeField] private int Seed2;
    [SerializeField] private int Frequency2;
    [SerializeField] private int OffsetX2;
    [SerializeField] private int OffsetY2;
    [SerializeField] private GameObject enemy;

    void Start()
    {
        Generate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int a = 0; a < transform.childCount; a++) {
                Destroy(transform.GetChild(a).gameObject);  
            }
            Generate();
        }
    }
    public void Generate()
    {
        transform.position = new Vector2(-(Width / 2), -(Height / 2));
        Vector2 pos = transform.position;   
        for (int a = 0; a <= Height; a++)
        {
            for (int i = 0; i <= Width; i++)
            {
                if (a < ((Height / 2) - 2) || a > ((Height / 2) + 2))
                {
                    float perlinTerrain = Mathf.PerlinNoise((pos.x + i + Seed + OffsetX) / Frequency, (pos.y + a + Seed + OffsetY) / Frequency);
                    bool isTerra = perlinTerrain > 0.40f;
                    if (isTerra)
                    {
                        Vector2 PosBLoc = new Vector2(pos.x + i, pos.y + a);
                        Instantiate(blocTerra, PosBLoc, Quaternion.identity).transform.parent = transform;
                    }
                    else if (perlinTerrain < 0.15f)
                    {
                        Vector2 PosBLoc = new Vector2(pos.x + i, pos.y + a);
                        Instantiate(blocAigua, PosBLoc, Quaternion.identity).transform.parent = transform;
                    }
                    else
                    {
                        float perlinEnemies = Mathf.PerlinNoise((pos.x + i + Seed2 + OffsetX2) / Frequency2, (pos.y + a + Seed2 + OffsetY2) / Frequency2);
                        if (perlinEnemies < 0.25f)
                        {

                            if (a < Height / 2)
                                Instantiate(enemy, new Vector2(pos.x + i, pos.y + a), Quaternion.identity);
                            else
                            {
                                GameObject go = Instantiate(enemy, new Vector2(pos.x + i, pos.y + a), Quaternion.identity);
                                go.transform.Rotate(0, 0, 180);
                            }

                        }
                    }
                }else if((i < ((Width / 2) - 2) || i > ((Width / 2) + 2)))
                {
                    float perlinTerrain = Mathf.PerlinNoise((pos.x + i + Seed + OffsetX) / Frequency, (pos.y + a + Seed + OffsetY) / Frequency);
                    bool isTerra = perlinTerrain > 0.40f;
                    if (isTerra)
                    {
                        Vector2 PosBLoc = new Vector2(pos.x + i, pos.y + a);
                        Instantiate(blocTerra, PosBLoc, Quaternion.identity).transform.parent = transform;
                    }
                    else if (perlinTerrain < 0.15f)
                    {
                        Vector2 PosBLoc = new Vector2(pos.x + i, pos.y + a);
                        Instantiate(blocAigua, PosBLoc, Quaternion.identity).transform.parent = transform;
                    }
                    else
                    {
                        //float perlinEnemies = Mathf.PerlinNoise((pos.x + i + Seed2 + OffsetX2) / Frequency2, (pos.y + a + Seed2 + OffsetY2) / Frequency2);
                        //if (perlinEnemies < 0.25f)
                        //{

                        //    if (a < Height / 2)
                        //        Instantiate(enemy, new Vector2(pos.x + i, pos.y + a), Quaternion.identity);
                        //    else
                        //    {
                        //        GameObject go = Instantiate(enemy, new Vector2(pos.x + i, pos.y + a), Quaternion.identity);
                        //        go.transform.Rotate(0, 0, 180);
                        //    }

                        //}
                    }
                }
            }
        }
    }
}
