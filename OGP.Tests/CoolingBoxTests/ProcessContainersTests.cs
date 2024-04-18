using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OGP.Interface;
using OGP.Model;

namespace OGP.Tests.CoolingBoxTests
{
    [TestClass]
    public class ProcessContainersTests
    {
        [TestMethod]
        public void When_CoolingBoxColdnessIs10_IngredientColdnessIs5_Then_CoolWith5()
        {
            //Arrange
            Mock<ITemperature> ingredientTemp = new Mock<ITemperature>();
            ingredientTemp.SetupGet(x => x.Coldness).Returns(10);
            ingredientTemp.SetupGet(x => x.Hotness).Returns(0);
            Mock<IAlchemicIngredient> ingredient = new Mock<IAlchemicIngredient>();
            ingredient.SetupGet(x => x.Temperature).Returns(ingredientTemp.Object);
            Mock<IIngredientContainer> container = new Mock<IIngredientContainer>();
            container.SetupGet(x => x.Ingredient).Returns(ingredient.Object);
            
            var temp = new Temperature();
            temp.Cool(5);           
            CoolingBox box = new CoolingBox(temp);
            box.AddIngredient(container.Object);

            //Act
            box.ProcessContainers();

            //Assert
            ingredientTemp.Verify(x => x.Cool(5));
        }
    }
}
