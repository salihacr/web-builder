using WebBuilder.API.Dtos;

namespace WebBuilder.API.Services;

public interface IBuilderService
{
    bool Build(string projectId);
}
public class BuilderService : IBuilderService
{
    private readonly IGitService _git;
    public BuilderService(IGitService git)
    {
        _git = git;
    }
    public bool Build(string projectId)
    {
        // projeye git
        // pull et önce
        // sonra build et
        // switch case yap 
        // Project diye parametre alsın
        // Project dto içinde proje tipi alanı olsun dotnet, nodejs, java diye combobox dan seçebilsin proje yüklerken
        // proje yükle alanında github ssh vermesi lazım proje tipi seçmesi lazım adı da ekleyebilir
        throw new NotImplementedException();
    }


}