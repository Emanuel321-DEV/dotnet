using CleanArchMVC.Domain.Entities;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class ProductUnitTest1
    {

        private readonly string imgStringMock = new string('A', 250);

        [Fact(DisplayName = "Should be able create a new Product")]
        public void ShouldBeAbleCreateANewProduct()
        {
            Action action = () => new Product(1, "Iphone 11", "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .NotThrow <CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }


        [Fact(DisplayName = "Should be able create a new Product without Id")]
        public void ShouldBeAbleCreateANewProductWithoutId()
        {
            
            Action action = () => new Product("Iphone 11", "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Should not be able create a product with negative id")]
        public void ShouldNotBeAbleCreateAProductWithNegativeId()
        {
            
            Action action = () => new Product(-1, "Iphone 11", "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Should not be able create a product with empty name")]
        public void ShouldNotBeAbleCreateAProductWithEmptyName()
        {
            Action action = () => new Product(1, string.Empty, "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required");
        }

        [Fact(DisplayName = "Should not be able create a product with null name")]
        public void ShouldNotBeAbleCreateAProductWithNullName()
        {
            Action action = () => new Product(1, null, "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required");
        }



        [Fact(DisplayName = "Should not be able create a product with less than 3 characters")]
        public void ShouldNotBeAbleCreateAProductWithLessThanThreeCharacters()
        {
            Action action = () => new Product(1, "Ip", "Iphone 11 lacrado", 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Should not be able to create a product with empty description")]
        public void ShouldNotBeAbleCreateAProductWithEmptyDescription()
        {
            string description = string.Empty;
            Action action = () => new Product(1, "Product Name", description, 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required");
        }

        [Fact(DisplayName = "Should not be able to create a product with description less than 5 characters")]
        public void ShouldNotBeAbleCreateAProductWithDescriptionLessThanFiveCharacters()
        {
            string description = "abcd";
            Action action = () => new Product(1, "Product Name", description, 3000.00M, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Should not be able to create a product with negative price")]
        public void ShouldNotBeAbleCreateAProductWithNegativePrice()
        {
            decimal price = -10.00M;
            Action action = () => new Product(1, "Product Name", "Valid Description", price, 3, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Should not be able to create a product with negative stock")]
        public void ShouldNotBeAbleCreateAProductWithNegativeStock()
        {
            int stock = -5;
            Action action = () => new Product(1, "Product Name", "Valid Description", 3000.00M, stock, imgStringMock);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        // Teste para nome de imagem maior que 250 caracteres
        [Fact(DisplayName = "Should not be able to create a product with image name longer than 250 characters")]
        public void ShouldNotBeAbleCreateAProductWithImageNameLongerThan250Characters()
        {
            string longImageName = new string('A', 251); // 251 caracteres
            Action action = () => new Product(1, "Product Name", "Valid Description", 3000.00M, 3, longImageName);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        // Teste para atualização com descrição vazia
        [Fact(DisplayName = "Should not be able to update a product with empty description")]
        public void ShouldNotBeAbleToUpdateProductWithEmptyDescription()
        {
            string description = string.Empty;
            Product product = new Product(1, "Valid Name", "Valid Description", 3000.00M, 3, imgStringMock);
            Action action = () => product.Update("Product Name", description, 3000.00M, 3, imgStringMock, 1);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, Description is required");
        }

        
        [Fact(DisplayName = "Should not be able to update a product with description less than 5 characters")]
        public void ShouldNotBeAbleToUpdateProductWithDescriptionLessThanFiveCharacters()
        {
            string description = "abcd";
            Product product = new Product(1, "Valid Name", "Valid Description", 3000.00M, 3, imgStringMock);
            Action action = () => product.Update("Product Name", description, 3000.00M, 3, imgStringMock, 1);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description, too short, minimum 5 characters");
        }

        
        [Fact(DisplayName = "Should not be able to update a product with negative price")]
        public void ShouldNotBeAbleToUpdateProductWithNegativePrice()
        {
            decimal price = -10.00M;
            Product product = new Product(1, "Valid Name", "Valid Description", 3000.00M, 3, imgStringMock);
            Action action = () => product.Update("Product Name", "Valid Description", price, 3, imgStringMock, 1);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        
        [Fact(DisplayName = "Should not be able to update a product with negative stock")]
        public void ShouldNotBeAbleToUpdateProductWithNegativeStock()
        {
            int stock = -5;
            Product product = new Product(1, "Valid Name", "Valid Description", 3000.00M, 3, imgStringMock);
            Action action = () => product.Update("Product Name", "Valid Description", 3000.00M, stock, imgStringMock, 1);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        
        [Fact(DisplayName = "Should not be able to update a product with image name longer than 250 characters")]
        public void ShouldNotBeAbleToUpdateProductWithImageNameLongerThan250Characters()
        {
            string longImageName = new string('A', 251);
            Product product = new Product(1, "Valid Name", "Valid Description", 3000.00M, 3, imgStringMock);
            Action action = () => product.Update("Product Name", "Valid Description", 3000.00M, 3, longImageName, 1);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }




    }
}