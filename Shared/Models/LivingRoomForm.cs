using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class LivingRoomForm
{
    [Required(ErrorMessage = "O nome da sala é obrigatório!")]
    public string Name { get; set; }
}

