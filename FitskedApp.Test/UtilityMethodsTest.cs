using FitskedApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitskedApp.Test
{
    public class UtilityMethodsTest
    {

        [Fact]
        public void GenerateListOfNumbers_WithIncrementOfTwo_ReturnsCorrectList_Test()
        {
            // Arrange
            List<int> correctList = new List<int> {2, 4, 6, 8, 10};
            int start = 2;
            int end = 10;
            int increment = 2;
            
            // Act
            List<int> returnList = ListOfNumberHelper.GenerateListOfNumbers(start, end, increment);

            // Assert
            Assert.True(returnList.SequenceEqual(correctList));
        }
    }
}
