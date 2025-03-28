using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Atlantic.Api.Data.NotificationTemplatesContext.Entities;
using Atlantic.Api.Models.Enums;

namespace Atlantic.Api.Data.NotificationTemplatesContext.Repositories
{
    [ExcludeFromCodeCoverage]
    public class NotificationsRepository : INotificationRepository
    {
        private readonly NotificationTemplatesContext _context;
        
        public NotificationsRepository(NotificationTemplatesContext context)
        {
            _context = context;
        }

        private string DEFAULT_USER = "DIGITALBOT";
        private string DEFAULT_P = "API_SMARTSALES";

        public async Task<List<NotificationTemplateEntity>> GetAllTemplates()
        {
            return await _context.ststblwtpwpptemplates.ToListAsync();
        }

        public async Task<NotificationTemplateEntity> CreateTemplate(NotificationTemplateDTO newTemplate)
        {
            var lastId = await _context.ststblwtpwpptemplates.MaxAsync(p => (int?)p.wtpseq) ?? 0;

            var data = new NotificationTemplateEntity()
            {
                wtpseq = lastId + 1,
                wtpnomtemplate = newTemplate.Template,
                wtpcodblcbottpl = newTemplate.StateId,
                wtpidttypentfcapi = newTemplate.NotificationType,
                hdrdthins = newTemplate.CreatedAt,
                hdrdthhor = newTemplate.UpdatedAt,
                hdrcodusu = DEFAULT_USER,
                hdrcodlck = 1,
                hdrcodetc = DEFAULT_P,
                hdrcodprg = DEFAULT_P
            };

            _context.ststblwtpwpptemplates.Add(data);

            await _context.SaveChangesAsync();

            return data;
        }

        public async Task<List<NotificationTemplateEntity>> GetTemplatesByType(NotificationType type)
        {
            return await _context.ststblwtpwpptemplates
                           .Where(n => n.wtpidttypentfcapi == type)
                           .ToListAsync();
        }

        public async Task<List<NotificationTemplateEntity>> GetTemplatesByTemplate(string template)
        {
            return await _context.ststblwtpwpptemplates
                           .Where(n => n.wtpnomtemplate.Contains(template))
                           .ToListAsync();
        }

        public async Task<NotificationTemplateEntity> UpdateTemplate(NotificationTemplateEntity template)
        {
            var register = _context.ststblwtpwpptemplates.FirstOrDefault(n => n.wtpseq == template.wtpseq);

            await _context.SaveChangesAsync();

            return register;
        }

        public async Task<bool> DeleteTemplate(NotificationType type)
        {
            try
            {
                var register = _context.ststblwtpwpptemplates.FirstOrDefault(n => n.wtpidttypentfcapi == type);

                if (register != null)
                {
                    _context.ststblwtpwpptemplates.Remove(register);
                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
