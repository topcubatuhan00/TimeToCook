using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class ProductDetail : IDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string CreatedDate { get; set; }
        public string Amount { get; set; }
        public string SKTDate { get; set; }

    }
}
