using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RepoNotFoundException : Exception
    {
        public RepoNotFoundException()
        {
        }

        public RepoNotFoundException(string message) : base(message)
        {
        }

        public RepoNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepoNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
