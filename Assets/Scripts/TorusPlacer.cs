using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorusPlacer : MonoBehaviour, IVisualizer
{
    [SerializeField] private List<GameObject> _torusPrefabs = new List<GameObject>();
    
    public void Visualize(GameInfo gameInfo)
    {
        int count = 0;
        for (int i = 0; i < gameInfo.Info.Count; i++)
        {
            for (int j = 0; j < gameInfo.Info[i].Count; j++)
            {
                if (gameInfo.Info[i][j])
                {
                    gameInfo.GameSetup.AddTorus(i, _torusPrefabs[count]);
                    gameInfo.AnswerGameSetup.AddTorus(i, _torusPrefabs[count]);
                    count++;
                }
            }
        }

        gameInfo.GameSetup.Randomize(gameInfo.Seed, gameInfo.StickCapacity);
    }
}
