using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ConsoleVisualizer : MonoBehaviour, IVisualizer
{
    public void Visualize(GameInfo gameInfo)
    {
        for (int i = 0; i < gameInfo.Info.Count; i++)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("LINE: ");
            for (int j = 0; j < gameInfo.Info[i].Count; j++)
            {
                if (gameInfo.Info[i][j])
                {
                    stringBuilder.Append("1 ");
                }
            }

            Debug.Log(stringBuilder.ToString());
        }
    }
}
