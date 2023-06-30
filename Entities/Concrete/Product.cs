using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string CreatedDate { get; set; }
        public string Amount { get; set; }
        public string SKTDate { get; set; }
    }
}
