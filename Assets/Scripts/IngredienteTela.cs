using UnityEngine;

namespace CharllesDev
{
    [RequireComponent(typeof(Animator))]
    public class IngredienteTela : MonoBehaviour
    {
        [SerializeField] internal string Nome;
        [SerializeField] private Animator ani;

        private void OnValidate()
        {
            if (ani == null)
                ani = GetComponent<Animator>();

            Nome = this.gameObject.name;
        }

        public void TirarIngrediente()
        {
            ani.SetTrigger("Sair");
        }

        public void ExcluirIngrediente()
        {
            Destroy(this.gameObject);
        }
    }
}
