using LinnworksCSVBackend.Common.Requests;
using LinnworksCSVBackend.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Services.Interfaces
{
    public interface IGenericService<TEntity> : IDisposable where TEntity : class , new()
    {
        ListResponse<TEntity> List(ListRequest request);
        GetResponse<TEntity> GetById(GetRequest request);
        SaveResponse<TEntity> Add(SaveRequest<TEntity> request);
        SaveResponse<TEntity> Update(SaveRequest<TEntity> request);
        DeleteResponse<TEntity> Delete(DeleteRequest request);
    }
}
