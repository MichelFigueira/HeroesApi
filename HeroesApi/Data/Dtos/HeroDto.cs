using System.ComponentModel.DataAnnotations;

namespace HeroesApi.Data.Dtos
{
    public class HeroDto
    {
        [Required]
        public string Alias { get; set; }
        public string RealName { get; set; }
    }
}
