using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _photoImage;
    [SerializeField] private GameObject _photoPanel;

    [SerializeField] private float _time = 0.1f;
    [SerializeField] private LeanTweenType _type;

    [ContextMenu("Debug Photo")]
    public void MakePhoto()
    {
        LeanTween.value(1, 0, _time).setEase(_type).setOnUpdate((float x) =>
        {
            _photoImage.alpha = x;
        }).setOnComplete(() =>
        {
            _photoPanel.SetActive(true);
        });
    }
}
