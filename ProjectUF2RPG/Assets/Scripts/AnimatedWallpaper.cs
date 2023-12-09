using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedWallpaper : MonoBehaviour
{
    [SerializeField] public List<Sprite> sprites = new List<Sprite>();
    private int index;
    void Awake()
    {
        index = -1;
        StartCoroutine(updateImage());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator updateImage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            this.GetComponent<Image>().sprite = sprites[index + 1];
            if (index + 1 == 7)
            {
                index = -1;
            }
            else
            {
                index++;
            }
        }
    }
}
