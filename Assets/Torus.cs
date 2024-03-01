using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus : MonoBehaviour
{
    [SerializeField] private LayerMask _stickLayer;

    private Rigidbody _rigidbody;
    private LeanSelectable _leanSelectable;
    private DestroyTorus _destroyTorus;

    private Vector3 _startPosition;
    private Stick _stick;

    private bool _isDragged = false;

    private void Awake()
    {
        _leanSelectable = GetComponent<LeanSelectable>();
        _rigidbody = GetComponent<Rigidbody>();
        _destroyTorus = GetComponent<DestroyTorus>();
    }

    private void OnEnable()
    {
        _leanSelectable.OnSelect.AddListener(OnGrab);
        _leanSelectable.OnDeselect.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        _leanSelectable.OnSelect.RemoveListener(OnGrab);
        _leanSelectable.OnDeselect.RemoveListener(OnReleased);
    }

    public void OnGrab(LeanFinger finger)
    {
        _startPosition = transform.position;
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f, _stickLayer);
        if (colliders.Length != 0)
        {
            _stick = colliders[0].GetComponentInParent<Stick>();
            if (_stick.IsLast(gameObject))
            {
                _isDragged = true;
                _rigidbody.isKinematic = false;
                _stick.RemoveTorus();
            }
        }
    }

    public void OnReleased()
    {
        if (!_isDragged)
            return;

        _isDragged = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f, _stickLayer);
        if (colliders.Length != 0)
        {
            colliders[0].GetComponentInParent<Stick>().PlaceTorus(gameObject);
        }
        else
        {
            ReturnBack();
        }
    }

    private void ReturnBack()
    {
        _stick.PlaceTorus(gameObject);
    }
}
