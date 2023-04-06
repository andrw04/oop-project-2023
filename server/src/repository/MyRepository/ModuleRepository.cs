using Domain;

namespace Repository
{
    public class ModuleRepository : Repository
    {
        public IEnumerable<Module> FindAllByName(string name)
        {
            List<Module> result = new();
            foreach(var item in storage)
            {
                var module = (Module)item;
                if(module.Name == name)
                    result.Add(module);
            }
            return result;
        }
        public IEnumerable<Module> FindAllByAuthorName(string name)
        {
            List<Module> result = new();
            foreach(var item in storage)
            {
                var module = (Module)item;
                if(module.Author == name)
                    result.Add(module);
            }
            return result;
        }    
    }
}