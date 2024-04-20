namespace DepartAdmin.DAL.Exceptions
{
    public class DaoPagoException : Exception
    {
        public DaoPagoException(string Message) : base(Message)
        {
            // x logica para guardar el error.
        }
    }
}