using UnityEngine;

namespace DefaultNamespace
{
    public class Figure : MonoBehaviour
    {
        [SerializeField] private MeshRenderer renderer;

        public Cell CurrentCell { get; set; }

        public void SetColor(ColorType colorType)
        {
            Color color = Color.clear;
            switch (colorType)
            {
                case ColorType.Black:
                    color=Color.black;
                    break;
                case ColorType.White:
                    color = Color.white;
                    break;
                case ColorType.None:
                    return;
            }

            renderer.material.color = color;
        }
    }
}