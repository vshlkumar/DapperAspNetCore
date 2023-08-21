using Dapper.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Services.Service
{
    public class InstanceLifetimeService : IInstanceLifetimeService
    {
        private readonly ITransientInstanceLifetimeService _transientInstance;
        private readonly IScopedInstanceLifetimeService _scopedInstance;
        private readonly ISingletonInstanceLifetimeService _singletonInstance;
        public InstanceLifetimeService(ISingletonInstanceLifetimeService singletonInstance, 
            IScopedInstanceLifetimeService scopedInstance, 
            ITransientInstanceLifetimeService transientInstance)
        {

            _singletonInstance= singletonInstance;
            _scopedInstance= scopedInstance;

            _transientInstance= transientInstance;
        }


        public string getScoped()
        {
            return _scopedInstance.OperationId;
        }

        public string getSingleton()
        {
            return _singletonInstance.OperationId;
        }

        public string getTransient()
        {
            return _transientInstance.OperationId;
        }
    }
}
