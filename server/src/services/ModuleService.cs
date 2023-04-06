using Domain;
using Repository;

namespace Services
{
    public class ModuleService
    {
        public ModuleService(IModuleRepository repository)
        {
            modules = repository;
        }
        public void CreateModule(string name, string description, string img, string author)
        {
            modules.Save(new Module(name,description,img,author));
        }
        public void AddModule(Module module)
        {
            modules.Save(module);
        }

        public void DeleteModule(long id)
        {
            modules.DeleteById(id);
        }

        private IModuleRepository modules;

    }
}