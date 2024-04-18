using OGP.Interface;

namespace OGP.Model
{
    public class IngredientContainer: IIngredientContainer
    {
        public IAlchemicIngredient Ingredient { get; set; }
    }
}
