using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;
using BuberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTest
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTest()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //Arrange



        //Act
        var result = await _handler.Handle(createMenuCommand, default);
        //Assert

        result.IsError.Should().BeFalse();

        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
    }
}