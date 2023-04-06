using Domain;

namespace Repository
{
    public class ModuleRepository : IModuleRepository
    {
        public long Count()
        {
            return modules.Count;
        }

        public void DeleteAll(IEnumerable<Module> entities)
        {
            foreach(var entity in entities)
            {
                if(ExistsById(entity.Id))
                    modules.Remove(entity);
            }
        }

        public void DeleteById(long id)
        {
            var module = FindById(id);
            if(module != null)
                modules.Remove(module);
        }

        public bool ExistsById(long id)
        {
            var module = FindById(id);
            if(module != null)
                return true;
            else
                return false;
        }

        public IEnumerable<Module> FindAllByAuthorName(string name)
        {
            List<Module> result = new();
            foreach(var module in modules)
            {
                if(module.Author == name)
                    result.Add(module);
            }
            return result;
        }

        public IEnumerable<Module> FindAllByName(string name)
        {
            List<Module> result = new();
            foreach(var module in modules)
            {
                if(module.Name == name)
                    result.Add(module);
            }
            return result;
        }

        public Module? FindById(long id)
        {
            foreach(var module in modules)
            {
                if(module.Id == id)
                    return module;
            }
            return null;
        }

        public void Save(Module entity)
        {
            if(FindById(entity.Id) == null)
                modules.Add(entity);
        }

        private List<Module> modules = new();
    }
}