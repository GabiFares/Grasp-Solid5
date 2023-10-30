using System.IO;

namespace Full_GRASP_And_SOLID
{
    public class FilePrinter : IPrinter
    {
        public void PrintRecipe(IRecipeContet recipeContet)
        {
            File.WriteAllText("Recipe.txt", recipeContet.GetTextToPrint());
        }
    }
}