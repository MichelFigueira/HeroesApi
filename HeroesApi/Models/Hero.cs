using System.ComponentModel.DataAnnotations;

namespace HeroesApi.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        public string Alias  { get; set; }
        public string RealName { get; set; }
    }
}
