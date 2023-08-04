using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Interfaces.Generics
{
    public interface IControllerBase<TEntity> where TEntity : BaseEntity
    {
        Task<ResultPage<TEntity>> GetAsync();
        Task<IActionResult> Get([FromRoute] int id);
        Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] TEntity model);
        Task<IActionResult> PostAsync([FromBody] TEntity model);
        Task<IActionResult> DeleteAsync([FromRoute] int id);

    }
}
