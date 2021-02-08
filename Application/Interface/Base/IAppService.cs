using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface.Base
{
    public interface IAppService<T> where T : class
    {
        Task<T> Add(T viewModel);


        IEnumerable<T> GetAll();

    }
}