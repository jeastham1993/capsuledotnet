using System;
using System.Threading.Tasks;

namespace CapsuleDotNet.Common{
    public abstract class DefaultObjectWrapper
    {
        public DefaultObjectWrapper(){
            this.Pagination = new QueryPagination();    
        }

        internal QueryPagination Pagination {get;set;}

        public virtual async Task<T> NextPage<T>() where T : DefaultObjectWrapper {
            if (this.Pagination.NextLink == null){
                return null;
            }

            var partyWrapper = await CapsuleClient.makeRequest<T>(this.Pagination.NextLink, "GET");

            return partyWrapper;
        }

        public virtual async Task<T> PrevPage<T>() where T : DefaultObjectWrapper {
            if (this.Pagination.PrevLink == null){
                return null;
            }

            var partyWrapper = await CapsuleClient.makeRequest<T>(this.Pagination.PrevLink, "GET");

            return partyWrapper;
        }
    }
}