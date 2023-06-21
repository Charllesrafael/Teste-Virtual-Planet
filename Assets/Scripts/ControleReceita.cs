using System.Net.Mime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CharllesDev
{
    public class ControleReceita : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nomeSanduiche;
        [SerializeField] private Image iconeSanduiche;
        [SerializeField] private IngredientesUI prefabItemReceita;
        [SerializeField] private RectTransform paiItensReceita;
        [SerializeField] private List<Sanduiche> sanduiches;

        private int ultimoSanduiche = -1;
        private List<IngredientesUI> ingredientesReceita;

        public void NovoSanduiche()
        {
            int sanduicheAtual = UnityEngine.Random.Range(0, sanduiches.Count);
            while (ultimoSanduiche == sanduicheAtual)
            {
                sanduicheAtual = UnityEngine.Random.Range(0, sanduiches.Count);
            }
            ultimoSanduiche = sanduicheAtual;
            ReceberReceita(sanduiches[sanduicheAtual]);
        }

        public void ReceberReceita(Sanduiche sanduiche)
        {
            ingredientesReceita = new List<IngredientesUI>();
            for (int i = paiItensReceita.childCount - 1; i >= 0; i--)
            {
                Destroy(paiItensReceita.GetChild(i).gameObject);
            }

            nomeSanduiche.text = sanduiche.Nome;
            iconeSanduiche.sprite = sanduiche.Icone;

            foreach (var ingrediente in sanduiche.ingredientes)
            {
                IngredientesUI current = Instantiate(prefabItemReceita, paiItensReceita);
                current.Config(ingrediente.Icone, ingrediente.Nome);
                ingredientesReceita.Add(current);
            }
        }

        public bool IngredienteColocado(IngredienteTela ingredienteTela)
        {
            if (ingredientesReceita == null)
                return false;

            foreach (var item in ingredientesReceita)
            {
                if (item.nome.text == ingredienteTela.Nome)
                {
                    item.Verificar(true);
                    return true;
                }
            }
            return false;
        }

        internal void RemoverIngrediente(IngredienteTela ingredienteTela)
        {
            if (ingredientesReceita == null)
                return;

            foreach (var item in ingredientesReceita)
            {
                if (item.nome.text == ingredienteTela.Nome)
                {
                    item.Verificar(false);
                    break;
                }
            }
        }
    }
}
