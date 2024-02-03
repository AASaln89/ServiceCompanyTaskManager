namespace ServiceCompanyTaskManager.Common.Models.Entities
    {
    public interface IEntity
    {
        public int Id { get; set; }

        public Guid UUID { get; set; }
    }
}
