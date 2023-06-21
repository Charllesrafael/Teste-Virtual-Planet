using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharllesDev
{
    public class IngredientesUI : MonoBehaviour
    {
        [SerializeField] private Image icone;
        [SerializeField] internal TextMeshProUGUI nome;
        [SerializeField] private GameObject verificado;

        public void Config(Sprite _icone, string _nome)
        {
            icone.sprite = _icone;
            nome.text = _nome;
        }

        public void Verificar(bool valido)
        {
            verificado.SetActive(valido);
        }
    }
}
