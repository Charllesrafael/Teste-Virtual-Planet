using UnityEngine;

namespace CharllesDev
{
    [CreateAssetMenu(fileName = "Sanduiche", menuName = "Teste Virtual Planet/Sanduiche", order = 0)]
    public class Sanduiche : ScriptableObject
    {
        [SerializeField] internal string Nome;
        [SerializeField] internal Sprite Icone;
        [SerializeField] internal Ingredientes[] ingredientes;
    }
}
