using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    [SerializeField] private List<Stick> _sticks = new List<Stick>();

    public void AddTorus(int index, GameObject torus)
    {
        _sticks[index].AddTorus(torus);
    }

    public int Randomize(int seed, int capacity)
    {
        int stepCount = 0;

        System.Random random = new System.Random(seed);

        for (int i = 0; i < 10; i++)
        {
            int stickFromIndex = 0;

            Stick stickFrom = null;

            do
            {
                stickFromIndex = random.Next(0, _sticks.Count);
            }
            while (_sticks[stickFromIndex].Count == 0);

            stickFrom = _sticks[stickFromIndex];
            var torus = _sticks[stickFromIndex].RemoveTorus();

            int stickToIndex = 0;

            do
            {
                stickToIndex = random.Next(0, _sticks.Count);
            }
            while (_sticks[stickToIndex].Count >= capacity || stickFrom == _sticks[stickToIndex]);

            stepCount++;
            _sticks[stickToIndex].PlaceTorus(torus);
        }

        Debug.Log(stepCount);
        return stepCount;
    }
}
