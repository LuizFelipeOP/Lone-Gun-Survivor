using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeShotScript : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    public float moveSpeed;

    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //Set the GameObject's Color quickly to a set Color (blue)
        m_SpriteRenderer.color = Color.blue;

        moveSpeed = 6.0f;
    }


}
