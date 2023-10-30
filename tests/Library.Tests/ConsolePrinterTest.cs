using Full_GRASP_And_SOLID;
using NUnit.Framework;

namespace Library.Tests;

public class ConsolePrinterTest
{
    [Test]

    public void Test()
    {
        // Arrange
        Product coffee = new Product("Coffee", 100);
        Equipment coffeePot = new Equipment("CoffePot", 120);
        Recipe recipe = new Recipe();
        recipe.FinalProduct = coffee;
        recipe.AddStep(coffee, 100, coffeePot, 120); // Ya no es necesario poner "new step"
        IPrinter consolePrinter = new ConsolePrinter();

        // Me puse a buscar como podía hacer este test para poder capturar el output, y me encontré con el "StringWriter". 
        // Estas líneas que aparencen debajo permite capturar la salida de Console.WriteLine(), para después poder comparar lo esperado con la salida.
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            consolePrinter.PrintRecipe(recipe);

            // Assert 
            string expectedOutput = recipe.GetTextToPrint().Trim();
            string consoleOutput = sw.ToString().Trim();
            Assert.That(consoleOutput, Is.EqualTo(expectedOutput));
        }
    }

}