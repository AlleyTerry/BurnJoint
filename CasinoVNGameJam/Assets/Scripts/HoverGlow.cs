using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverGlow : MonoBehaviour
{
    private void OnMouseEnter()
    {
        //collision to glow
        var renderer = GetComponent<SpriteRenderer>();
        //set alpha to 0.5f
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0.5f);

    }
    private void OnMouseExit()
    {
        //collision to stop glowing
        var renderer = GetComponent<SpriteRenderer>();
        
        //set alpha to 0f
        renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0f);
    }
}
