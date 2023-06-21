using UnityEngine;

namespace CharllesDev
{
    [CreateAssetMenu(fileName = "Ingrediente", menuName = "Teste Virtual Planet/Ingrediente", order = 0)]
    public class Ingredientes : ScriptableObject
    {
        [SerializeField] internal string Nome;
        [SerializeField] internal Sprite Icone;
    }
}
