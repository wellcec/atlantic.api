using Atlantic.Api.Data.NotificationTemplatesContext.Entities;
using Atlantic.Api.Models.Enums;

namespace Atlantic.Api.Data.NotificationTemplatesContext.Repositories
{
    public interface INotificationRepository
    {
        public Task<List<NotificationTemplateEntity>> GetAllTemplates();

        public Task<NotificationTemplateEntity> CreateTemplate(NotificationTemplateDTO newTemplate);

        public Task<List<NotificationTemplateEntity>> GetTemplatesByType(NotificationType type);

        public Task<NotificationTemplateEntity> UpdateTemplate(NotificationTemplateEntity template);

        public Task<List<NotificationTemplateEntity>> GetTemplatesByTemplate(string template);

        public Task<bool> DeleteTemplate(NotificationType type);
    }
}
