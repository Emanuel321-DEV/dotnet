using CleanArchMVC.Domain.Entities;
using FluentAssertions;

namespace CleanArchMVC.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Should be able create a new Category")]
        public void ShouldBeAbleCreateANewCategory()
        {

            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow <CleanArchMVC.Domain.Validation.DomainExceptionValidation>();

        }


        [Fact(DisplayName = "Should not be able create a category with negative id")]
        public void ShouldNotBeAbleCreateACategoryWithNegativeId()
        {
            Action action = () => new Category(-1, "Category test");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }


        [Fact(DisplayName = "Should not be able create a category with less than 3 characters")]
        public void ShouldNotBeAbleCreateACategoryWithLessThanThreeCharacters()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, too short, minimum 3 charecters");
        }



        [Fact(DisplayName = "Should not be able create a category with empty name")]
        public void ShouldNotBeAbleCreateACategoryWithEmptyName()
        {
            Action action = () => new Category(1, string.Empty);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required");
        }

        [Fact(DisplayName = "Should not be able create a category with null name")]
        public void ShouldNotBeAbleCreateACategoryWithNullName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name, Name is required");
        }


    }
}