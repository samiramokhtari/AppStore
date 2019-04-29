using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppStore.Models
{
    public class OperationResult
    {
        private Exception _exception = null;

        public bool Succeed
        {
            get
            {
                return this._exception == null;
            }
        }

        public string Message
        {
            get
            {
                if (this.Exception == null)
                    return null;

                return this._exception.Message;
            }
        }

        public Exception Exception
        {
            get
            {
                if (this._exception == null)
                    return null;

                return this._exception;
            }
        }

        public Exception InnerException
        {
            get
            {
                if (this.Exception == null)
                    return null;

                Exception innerException = this.Exception.InnerException;

                while (innerException != null)
                    if (innerException.InnerException != null)
                        innerException = innerException.InnerException;
                    else
                        return innerException;

                return innerException;
            }
        }

        public OperationResult(Exception ex, bool logError = true)
        {
            this._exception = ex;
        }
    }
}
