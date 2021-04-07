using LinnworksCSVBackend.Common.Helpers;
using LinnworksCSVBackend.Common.Requests;
using LinnworksCSVBackend.Common.Responses;
using LinnworksCSVBackend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LinnworksCSVBackend.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class, new()
    {
        private bool disposedValue;
        internal DbContext Context;
        internal DbSet<TEntity> DBSet;
        private readonly IHttpContextAccessor accessor;

        public GenericService(DbContext _context/*, IHttpContextAccessor _accessor*/)
        {
            Context = _context;
            DBSet = Context.Set<TEntity>();
            //accessor = _accessor;
        }

        public async Task<SaveResponse<TEntity>> AddAsync(SaveRequest<TEntity> request)
        {
            var userId = Guid.NewGuid();
            
            var entity = request.Data;
            var transactionId = TransactionHelper.GetTransactionId();
            AddParamValueEntity(entity, "CreateDate", DateTime.Now);
            //AddParamValueEntity(entity, "UserId", userId);
            AddParamValueEntity(entity, "TransactionId", transactionId);
            await DBSet.AddAsync(entity);

            {
               await Context.SaveChangesAsync();
            }

            return new SaveResponse<TEntity>();
        }

        public DeleteResponse<TEntity> Delete(DeleteRequest request)
        {
            throw new NotImplementedException();
        }

        public GetResponse<TEntity> GetById(GetRequest request)
        {
            throw new NotImplementedException();
        }

        public ListResponse<TEntity> List(ListRequest request)
        {
            throw new NotImplementedException();
        }

        public SaveResponse<TEntity> Update(SaveRequest<TEntity> request)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~GenericService()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }


        public TEntity AddParamValueEntity<TEntity>(TEntity entity, string paramname, object value)
        {
            PropertyInfo propOperationTypeId = entity.GetType().GetProperty(paramname, BindingFlags.Public | BindingFlags.Instance);
            if (null != propOperationTypeId && propOperationTypeId.CanWrite)
            {
                propOperationTypeId.SetValue(entity, value, null);
            }
            return entity;
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
