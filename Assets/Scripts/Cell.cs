using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

//First i think of making this class Scriptable object, but then i think i need to access cells position,
//which i cant assign within it, so i make it simple serializable class. I do not sure if it right or not and how can i make it better
[Serializable]
public class Cell
{
    [SerializeField] private string name;
    [SerializeField] private Transform cellPosition;
    [SerializeField] private ColorType colorType;
    [SerializeField] private FigureConfig figureConfig;

    public Figure currentFigure;
    public Vector2Int index;

    public Transform CellPosition => cellPosition;
    public ColorType ColorType => colorType;
    public FigureConfig FigureConfig => figureConfig;
}
