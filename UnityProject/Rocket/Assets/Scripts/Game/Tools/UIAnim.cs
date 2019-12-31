using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnim : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_Sprites;
    public float speed = 10;
    [SerializeField]
    private Image m_Sprite;


    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * speed) % m_Sprites.Length;
        m_Sprite.sprite = m_Sprites[index];

    }
}
