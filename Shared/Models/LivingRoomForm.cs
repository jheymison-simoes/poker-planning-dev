using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class LivingRoomForm
{
    [Required]
    public string Name { get; set; }
}

