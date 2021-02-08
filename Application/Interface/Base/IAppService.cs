using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface.Base
{
    public interface IAppService<T> where T : class
    {
        Task<T> Add(T viewModel);

        long GenerateId();

        T GetById(string id);

        IEnumerable<T> GetAll();

        T Update(T viewModel);
        void Remove(T viewModel);

    }
}