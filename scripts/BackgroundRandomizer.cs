using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundRandomizer : MonoBehaviour
{

    //This class selects a random texture from a 'Backgrounds' folder and sets it on canvas image
    void Start()
    {
        Object[] textures = Resources.LoadAll("Backgrounds", typeof(Texture2D));
        int t = (int)Random.Range(0, textures.Length - 1);
        Texture2D tex = (Texture2D)textures[t];
        try
        {
            transform.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        }
        catch
        {
            Debug.Log("Background Randomizer: Failed to set BG image");
        }
    }

}
