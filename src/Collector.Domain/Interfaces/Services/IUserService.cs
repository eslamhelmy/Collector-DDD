using Collector.Domain.ViewModels;
using Collector.Mappers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Domain.Services
{
    public interface IUserService
    {
        Task<ResponseViewModel<TokenViewModel>> Login(UserViewModel viewModel);
    }
}
