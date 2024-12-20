﻿using Gestor.Domain.Enums;

namespace Gestor.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public bool IsActived { get; set; }

        public bool ChangePassword { get; set; }
        public int? Deleted { get; set; }

        public string Token { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdateAt { get; set; }

        public int EstablishmentId { get; set; }

        public virtual Establishment Establishment { get; set; }

        public Role Role { get; set; } = Role.Operator;
    }
}