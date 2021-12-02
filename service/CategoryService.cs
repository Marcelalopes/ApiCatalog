using api_catalogo.models;

namespace api_catalogo.service
{
    public class CategoryService
    {
        public string GetAll() {
            return "Todas as Categorias";
        }

        public Category Add(Category category) {
            return category;
        }

        public string Update() {
            return "Atualizar Categorias";
        }

        public string Delete() {
            return "Deletar Categoria";
        }
    }
}