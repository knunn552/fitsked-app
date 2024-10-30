using Bunit;
using FitskedApp.Components.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace FitskedApp.Test
{
    public class TestPageTest
    {
        [Fact]
        public void Basic_Markup_TestPageRendersCorrectly_Test()
        {
            //Arrange
            using var ctx = new TestContext(); // Tet Context comes from B unit which allows us to verify that the page renders correctly

            // Act
            var renderedComponent = ctx.RenderComponent<Components.Pages.Testpage>();

            // Assert
            renderedComponent.MarkupMatches("<h3>Testpage</h3>");
        }

        [Fact]
        public void BasicDOM_Markup_TestPageRendersCorrectly_Test()
        {
            //Arrange
            using var ctx = new TestContext(); // Tet Context comes from B unit which allows us to verify that the page renders correctly

            // Act
            var renderedComponent = ctx.RenderComponent<Components.Pages.Testpage>();

            // Assert
            var h1Element = renderedComponent.Find("h3");
            h1Element.MarkupMatches("<h3>Testpage</h3>");
        }
    }
}