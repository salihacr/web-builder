namespace WebBuilder.API.Services;

public interface IBuilderService
{
    bool Build();
}
public class BuilderService : IBuilderService
{
    public bool Build()
    {
        // pull et önce
        // sonra build et
        // switch case yap 
        // Project diye parametre alsın
        // Project dto içinde proje tipi alanı olsun dotnet, nodejs, java diye combobox dan seçebilsin proje yüklerken
        // proje yükle alanında github ssh vermesi lazım proje tipi seçmesi lazım adı da ekleyebilir
        throw new NotImplementedException();
    }
}