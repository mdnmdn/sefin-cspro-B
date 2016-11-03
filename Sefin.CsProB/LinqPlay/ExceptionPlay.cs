using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPlay
{
    public class ExceptionPlay
    {

        public void TestException() {

            try
            {
                ProcessaCose();
            }
            catch (Exception ex)
            {
                //ex.in
                throw new Exception("errore nel process del documento X ", ex);

                //Console.WriteLine(ex.Message);

                //Console.WriteLine(ex.ToString());
            }
            finally
            {

            }

        }

        /// <summary>
        /// 0 ok, se maggiore di zero corrisponde al codice di errore
        /// </summary>
        /// <returns></returns>
        //public int LoadFile() {
        //    return 0;
        //}

        private void ProcessaCose()
        {
            throw new NotImplementedException();
        }
    }


    public class SefinBaseException : Exception {

        public Guid UniqueId { get; protected set; }

        public SefinBaseException(string message, Exception innerException = null) 
            : base(message, innerException) {

            var sefinInner = innerException as SefinBaseException;
            if (sefinInner != null)
                UniqueId = sefinInner.UniqueId;
            else
                UniqueId = Guid.NewGuid();

        }

        public override string ToString()
        {
            return $"SefinEx ID: {UniqueId} - " + base.ToString();
        }
    }

    public class SefinPublicException : SefinBaseException {

        public string PublicMessage { get; protected set; }

        public SefinPublicException(string message, string publicMessage, Exception innerException = null) 
            : base(message, innerException){

            PublicMessage = publicMessage;
        }

    }

}
