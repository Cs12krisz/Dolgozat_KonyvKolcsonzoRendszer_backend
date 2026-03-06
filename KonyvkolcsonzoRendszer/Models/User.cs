using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KonyvkolcsonzoRendszer.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    public string? Salt { get; set; }
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
