using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CharllesDev
{
    public class ContagemRegressiva : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textoContagem;
        [SerializeField] private UnityEvent OnFimContagem;
        private int contagem = 3;

        public void FimContagem()
        {
            contagem = 3;
            textoContagem.text = contagem.ToString();
            OnFimContagem?.Invoke();
        }

        public void UpdateContagem()
        {
            contagem--;
            if (contagem <= 0)
                textoContagem.text = "GO";
            else
                textoContagem.text = contagem.ToString();
        }

    }
}
