using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPanel : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Init(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
