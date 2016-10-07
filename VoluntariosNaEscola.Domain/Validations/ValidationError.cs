namespace VoluntariosNaEscola.Domain.Validations
{
    public class ValidationError
    {
        public string MessageSystem { get; set; }

        public string MessageUser { get; set; }

        public string StackTrace { get; set; }

        public ValidationError(string message)
        {
            MessageSystem = message;
        }

        public ValidationError(string msgSystem, string msgUser, string stackTrace) : this(msgSystem)
        {
            MessageUser = msgUser;
            StackTrace = stackTrace;
        }
    }
}