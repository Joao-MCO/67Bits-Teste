using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public Color[] colors;
    public void Change()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        int level = GameController.Instance.collectionLevel;
        renderer.material.color = colors[level];
    }
}
