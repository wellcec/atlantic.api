using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Atlantic.Api.Models.Enums;

namespace Atlantic.Api.Data.NotificationTemplatesContext.Entities
{
    public class NotificationTemplateDTO
    {
        public long Id { get; set; }

        public string Template { get; set; } = string.Empty;

        public string? PreviousTemplate { get; set; } = string.Empty;

        public string StateId { get; set; } = string.Empty;

        public NotificationType NotificationType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class NotificationTemplateEntity
    {
        [Key]
        public long wtpseq { get; set; }

        public string wtpnomtemplate { get; set; } = string.Empty;

        public string? wtpdesprevtpl { get; set; } = string.Empty;

        public string wtpcodblcbottpl { get; set; } = string.Empty;

        public NotificationType wtpidttypentfcapi { get; set; }

        public DateTime hdrdthins { get; set; }

        public DateTime hdrdthhor { get; set; }

        public string hdrcodusu { get; set; }

        public int hdrcodlck { get; set; }

        public string hdrcodetc { get; set; }

        public string hdrcodprg { get; set; }
    }
}
