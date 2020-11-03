using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "figure", menuName = "Chess/Figure Config", order = 0)]
    public class FigureConfig : ScriptableObject
    {
        [SerializeField] private FigureType figureType;
        [SerializeField] private Figure prefab;
        [SerializeField] private MovementType _movementType;

        public FigureType FigureType => figureType;
        public Figure Prefab => prefab;

        public MovementType MovementType => _movementType;
    }
}