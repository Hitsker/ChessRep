using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//the idea here is that you can setup every cell's state via inspector on field prefab,
//so to create different field variants you simply create different field prefab variants
//and change states of cells there
public class Field : MonoBehaviour
{
    [SerializeField] private List<CellRaw> cells;

    private void Start()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            for (int j = 0; j < cells[i].cells.Count; j++)
            {
                cells[i].cells[j].index = new Vector2Int(i, j);
                
                if (cells[i].cells[j].FigureConfig!=null)
                {
                    var figure = Instantiate(cells[i].cells[j].FigureConfig.Prefab, cells[i].cells[j].CellPosition);
                    figure.SetColor(cells[i].cells[j].ColorType);
                    figure.CurrentCell = cells[i].cells[j];
                    cells[i].cells[j].currentFigure = figure;
                }
            }
        }
    }

    public bool IsCellEmpty(Vector2Int index)
    {
        return cells[index.x].cells[index.y].currentFigure == null;
    }

    public Transform GetPositionByCell(Vector2Int index)
    {
        return cells[index.x].cells[index.y].CellPosition;
    }

    public Cell GetCellByIndex(Vector2Int index)
    {
        return cells[index.x].cells[index.y];
    }
}

[Serializable]
public class CellRaw
{
    public string name;
    public List<Cell> cells;
}
