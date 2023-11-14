using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTests.TestUtils.Contansts;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateMenuCommand() =>
    new(
        Constants.Host.Id.ToString()!,
    Constants.Menu.Name,
    Constants.Menu.Description,
     CreateSectionsCommand(3));

    public static List<MenuSectionCommand> CreateSectionsCommand(int sectionCount = 1) =>
   Enumerable.Range(0, sectionCount)
   .Select(index => new MenuSectionCommand(
    Constants.Menu.SectionNameFromIndex(index),
    Constants.Menu.SectionDescriptionFromIndex(index),
    CreateItemsCommand(sectionCount)
   )).ToList();

    public static List<MenuItemCommand> CreateItemsCommand(int sectionCount = 1) =>
    Enumerable.Range(0, sectionCount)
    .Select(index => new MenuItemCommand(
     Constants.Menu.ItemNameFromIndex(index),
     Constants.Menu.ItemDescriptionFromIndex(index)
    )).ToList();
}