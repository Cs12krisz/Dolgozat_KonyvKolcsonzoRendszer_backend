using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KonyvkolcsonzoRendszer.Models;

public partial class Book
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public int? UserId { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
}
