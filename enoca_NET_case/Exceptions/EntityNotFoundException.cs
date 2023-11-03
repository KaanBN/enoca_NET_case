namespace enoca_NET_case.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public override string Message => $"{Id} kimliğine sahip varlık bulunamadı";
    }
}
