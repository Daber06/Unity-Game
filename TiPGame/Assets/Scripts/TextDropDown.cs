using TMPro;
using UnityEngine;

public class TextDropDown : MonoBehaviour
{
    public RectTransform textRect;
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        textRect.anchoredPosition += Vector2.up * speed * Time.deltaTime;
    }
}
