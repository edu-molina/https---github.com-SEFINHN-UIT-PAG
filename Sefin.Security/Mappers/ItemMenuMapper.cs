using SAS_DTO;

namespace Sefin.Security.Mappers
{
    public static class ItemMenuMapper
    {
        public static Item toItem(this SAS_MENUS_DTO sasMenusDto)
        {
            var item = new Item
            {
                id = sasMenusDto.ID_MENU,
                nombre = sasMenusDto.NOMBRE_MENU,
                label = sasMenusDto.DESC_MENU,
                icon = sasMenusDto.ICO_MENU,
                url = sasMenusDto.METODO
            };

            return item;
        }
    }
}