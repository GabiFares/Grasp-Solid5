using Full_GRASP_And_SOLID;
using NUnit.Framework;

public class FilePrinterTests
{
    [Test]
    public void PrintTicket_WritesToFile()
    {
        // Arrange
        Product coffee = new Product("Coffee", 100);
        Equipment coffeePot = new Equipment("CoffeePot", 120);
        Recipe recipe = new Recipe();
        recipe.FinalProduct = coffee;
        recipe.AddStep(coffee, 100, coffeePot, 120); // Ya no es necesario poner "new step"
        IPrinter filePrinter = new FilePrinter();

        // En la siguiente línea se crea una variable que almacena el nombre del archivo en el que esperamos que FilePrinter
        // escriba la información. Esto permite que la prueba verifique si el archivo se ha creado correctamente y si su contenido 
        // es lo que esperamos.
        string filePath = "Recipe.txt";

        // Act
        filePrinter.PrintRecipe(recipe);

        // Assert
        // En la siguiente línea se verifica si el archivo se ha creado
        Assert.IsTrue(File.Exists(filePath));

        string expectedOutput = recipe.GetTextToPrint();
        string fileContent = File.ReadAllText(filePath);
        Assert.That(fileContent.Trim(), Is.EqualTo(expectedOutput.Trim()));
    }
}
