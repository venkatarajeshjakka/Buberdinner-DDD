using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using BuberDinner.Domain.MenuAggregate;
using Mapster;
using MenuSection = BuberDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = BuberDinner.Domain.MenuAggregate.Entities.MenuItem;
namespace BuberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
        .Map(des => des.HostId, src => src.HostId)
        .Map(des => des, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
        .Map(dest => dest.Id, src => src.Id.Value)
        .Map(des => des.AverageRating, src => src.AverageRating.Value)
        .Map(des => des.HostId, src => src.Id.Value)
        .Map(des => des.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value))
        .Map(des => des.MenuReviewIds, src => src.MenuReviewIds.Select(reviewId => reviewId.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
        .Map(dest => dest.Id, src => src.Id.Value);

    }
}