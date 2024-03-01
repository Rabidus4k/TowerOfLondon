using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMovePanel : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _movePosition;

    [SerializeField] private float _time;
    [SerializeField] private LeanTweenType _type;


    [ContextMenu("Move Up")]
    public void MoveUp()
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveLocal(gameObject, _startPosition, _time).setEase(_type);
    }

    [ContextMenu("Move Down")]
    public void MoveDown() 
    {
        LeanTween.cancel(gameObject);
        LeanTween.moveLocal(gameObject, _movePosition, _time).setEase(_type);
    }
}
