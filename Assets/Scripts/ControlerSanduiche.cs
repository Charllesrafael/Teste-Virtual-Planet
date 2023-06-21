using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CharllesDev
{
    public class ControlerSanduiche : MonoBehaviour
    {
        [SerializeField] private ControleReceita controleReceita;
        [SerializeField] private Animator ani;
        [SerializeField] private TextMeshProUGUI textoAcertos;
        [SerializeField] private TextMeshProUGUI textoErros;
        [SerializeField] private TextMeshProUGUI pontuacaoFinal;

        [SerializeField] private int pontosBase = 1;

        [SerializeField] private float delayEntrega = 0.5f;
        [SerializeField] private float limiteIngrediente = 3;

        private int pontos = 0;
        private int acertos = 0;
        private int erros = 0;


        [SerializeField] private RectTransform paiSanduiche;
        [SerializeField] private IngredienteTela paoCima;
        [SerializeField] private IngredienteTela paoBaixo;
        private List<IngredienteTela> listaIngredientes;
        private bool finalizadoSanduiche;

        private void Start()
        {
            finalizadoSanduiche = false;
            listaIngredientes = new List<IngredienteTela>();
        }

        public void ReiniciarGame()
        {
            pontos = 0;
            acertos = 0;
            erros = 0;
            UpdateUI();

            finalizadoSanduiche = false;
            controleReceita.NovoSanduiche();
            ReceberReceita(paoBaixo);
        }

        public void ProximoSanduiche()
        {
            finalizadoSanduiche = false;
            controleReceita.NovoSanduiche();
            ReceberReceita(paoBaixo);
        }

        public void ReceberReceita(IngredienteTela ingrediente)
        {
            ReceberReceita(ingrediente, false);
        }

        public void ReceberReceita(IngredienteTela ingrediente, bool bypass = false)
        {
            if ((finalizadoSanduiche || listaIngredientes.Count > limiteIngrediente) && !bypass)
                return;


            foreach (var item in listaIngredientes)
            {
                if (item.Nome == ingrediente.Nome)
                    return;
            }


            listaIngredientes.Add(Instantiate(ingrediente, paiSanduiche));
            controleReceita.IngredienteColocado(ingrediente);
        }

        public void RemoverUltimoIngrediente()
        {
            if (finalizadoSanduiche)
                return;

            if (listaIngredientes.Count > 1)
            {
                listaIngredientes[listaIngredientes.Count - 1].TirarIngrediente();
                controleReceita.RemoverIngrediente(listaIngredientes[listaIngredientes.Count - 1]);
                listaIngredientes.RemoveAt(listaIngredientes.Count - 1);
            }
        }

        public void FinalizaSanduiche()
        {
            if (finalizadoSanduiche)
                return;

            finalizadoSanduiche = true;
            ReceberReceita(paoCima, true);
            StartCoroutine(EntregarSanduiche());
        }

        private IEnumerator EntregarSanduiche()
        {
            yield return new WaitForSeconds(delayEntrega);
            ani.SetTrigger("Pronto");
        }

        public void ExcluirIngredientes()
        {
            CalcularPontos();
            for (int i = 0; i < listaIngredientes.Count; i++)
                Destroy(listaIngredientes[i].gameObject);

            listaIngredientes.Clear();
        }

        public void ReiniciarSanduiche()
        {
            for (int i = 0; i < listaIngredientes.Count; i++)
                Destroy(listaIngredientes[i].gameObject);

            listaIngredientes.Clear();
        }

        private void CalcularPontos()
        {
            bool errou = false;
            if (listaIngredientes.Count < limiteIngrediente + 2)
            {
                errou = true;
            }
            else
            {
                foreach (var item in listaIngredientes)
                {
                    if (item.Nome.Contains("Pao"))
                        continue;

                    if (!controleReceita.IngredienteColocado(item))
                    {
                        errou = true;
                        break;
                    }
                }
            }

            pontos += errou ? -pontosBase : pontosBase;

            if (errou)
                erros++;
            else
                acertos++;

            UpdateUI();
        }

        private void UpdateUI()
        {
            textoAcertos.text = acertos.ToString("00");
            textoErros.text = erros.ToString("00");
            pontuacaoFinal.text = pontos.ToString("000");
        }
    }
}
