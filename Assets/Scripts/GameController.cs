using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Field field;
        [SerializeField] private Camera camera;
        [SerializeField] private Pointer pointer;
        [SerializeField] private Figures figures;

        private Figure currentSelected;
        private List<Pointer> currentPointers = new List<Pointer>();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    if (hit.transform.gameObject.CompareTag("Figure"))
                    {
                        var figure = hit.transform.gameObject.GetComponent<Figure>();
                        currentSelected = figure;
                        currentSelected.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                        ShowAvailableMovements(figure);
                    }
                    else if (hit.transform.gameObject.CompareTag("Pointer"))
                    {
                        currentSelected.transform.position = hit.transform.position;
                        var pointerHit = hit.transform.gameObject.GetComponent<Pointer>();
                        currentSelected.CurrentCell = pointerHit.cell;
                        pointerHit.cell.currentFigure = null;
                        
                        ClearSelection();
                    }
                }
                else
                {
                    ClearSelection();
                }

            }
        }

        private void ClearSelection()
        {
            foreach (var pointerCube in currentPointers)
            {
                Destroy(pointerCube.gameObject);
            }
            currentSelected.transform.localScale = Vector3.one;
            currentSelected = null;
        }
        
        private void ShowAvailableMovements(Figure figure)
        {
            var movementType = figures.GetMovementType(figure);
            switch (movementType)
            {
                case MovementType.Pawn:
                    PawnMovement(figure);
                    break;
                default:
                    PawnMovement(figure);
                    break;
            }
            
        }

        //test
        private void PawnMovement(Figure figure)
        {
            var currentIndex = figure.CurrentCell.index;
            var point1 = currentIndex - new Vector2Int(2, 0);
            var point2 = currentIndex - new Vector2Int(0, 2);
            var point3 = currentIndex - new Vector2Int(-2, 0);
            var point4 = currentIndex - new Vector2Int(0, -2);

            if (!IsOutOfBounds(point1))
            {
                if (field.IsCellEmpty(point1))
                {
                    var p = Instantiate(pointer, field.GetPositionByCell(point1));
                    p.cell = field.GetCellByIndex(point1);
                    currentPointers.Add(p);
                }
            }
            
            if (!IsOutOfBounds(point2))
            {
                if (field.IsCellEmpty(point2))
                {
                    var p = Instantiate(pointer, field.GetPositionByCell(point2));
                    p.cell = field.GetCellByIndex(point2);
                    currentPointers.Add(p);
                }
            }
            
            if (!IsOutOfBounds(point3))
            {
                if (field.IsCellEmpty(point3))
                {
                    var p = Instantiate(pointer, field.GetPositionByCell(point3));
                    p.cell = field.GetCellByIndex(point3);
                    currentPointers.Add(p);
                }
            }
            
            if (!IsOutOfBounds(point4))
            {
                if (field.IsCellEmpty(point4))
                {
                    var p = Instantiate(pointer, field.GetPositionByCell(point4));
                    p.cell = field.GetCellByIndex(point4);
                    currentPointers.Add(p);
                }
            }
        }
        
        private bool IsOutOfBounds(Vector2Int point)
        {
            return point.x <= 0 || point.x >= 7 || point.y <= 0 || point.y >= 7;
        }
    }
}