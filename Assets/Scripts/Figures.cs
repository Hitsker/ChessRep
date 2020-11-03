using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "figures", menuName = "Chess/Figures Config", order = 0)]
public class Figures : ScriptableObject
{
    [SerializeField] private List<FigureConfig> figures;

    public MovementType GetMovementType(FigureType figureType)
    {
        foreach (var figure in figures)
        {
            if (figure.FigureType==figureType)
            {
                return figure.MovementType;
            }
        }

        return MovementType.None;
    }
    
    public MovementType GetMovementType(Figure figurePrefab)
    {
        foreach (var figure in figures)
        {
            if (figure.Prefab==figurePrefab)
            {
                return figure.MovementType;
            }
        }

        return MovementType.None;
    }
}
