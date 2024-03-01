using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private float _offset;

    private List<GameObject> _spawnedObjects = new List<GameObject>();

    public int Count => _spawnedObjects.Count;

    public bool IsLast(GameObject torus)
    {
        return _spawnedObjects.Last() == torus;
    }

    public void AddTorus(GameObject torus)
    {
        GameObject newTorus = Instantiate(torus, transform);
        newTorus.transform.localPosition = new Vector3(0, _offset * _spawnedObjects.Count, 0);
        _spawnedObjects.Add(newTorus);
    }
    
    public GameObject RemoveTorus()
    {
        var torus = _spawnedObjects.Last();
        _spawnedObjects.Remove(torus);
        torus.transform.parent = null;
        return torus;
    }

    public void PlaceTorus(GameObject torus)
    {
        torus.transform.parent = transform;
        torus.transform.localPosition = new Vector3(0, _offset * _spawnedObjects.Count, 0);
        _spawnedObjects.Add(torus);
    }
}
