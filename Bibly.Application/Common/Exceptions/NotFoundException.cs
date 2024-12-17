namespace Bibly.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base($"Entity was not found") { }
    }
}
