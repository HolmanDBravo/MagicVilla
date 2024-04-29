using MagicVilla_API.Modelos.Dto;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> villaDtos = new List<VillaDto>
        {
            new VillaDto{ Id=1,Nombre="vista a la playa",Ocupantes=3,MetrosCuadrados=50},
            new VillaDto{ Id=2,Nombre="vista a la piscina",Ocupantes=4,MetrosCuadrados=80}
        };
    }
}
