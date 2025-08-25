namespace Ecommerce.API.Models.Common
{
    public class BaseEntity
    {
    public Guid Id { get; set; }
    public DateTime CreatedData { get; set; }
    }
}
//GUID (Globally Unique Identifier) — Küresel Olarak Benzersiz Tanımlayıcı. Yani her oluşturulduğunda dünyada eşi benzeri olmayan, benzersiz bir ID üretir. Toplamda 128-bit’lik bir değerdir.