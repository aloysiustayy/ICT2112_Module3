using System;
using System.Collections.Generic;

namespace DomainLayer.Entity;

public partial class NotificationLog
{
    public long NotifcationId { get; set; }

    public string NotificationTopic { get; set; } = null!;

    public string NotificationContent { get; set; } = null!;

    public string NotificationStatus { get; set; } = null!;

    public string NotificationType { get; set; } = null!;

    public string NotifcationDateTime { get; set; } = null!;

    public string AdministratorEmailAddress { get; set; } = null!;

    public string AdministratorPreferredNotification { get; set; } = null!;

    public virtual Administrator AdministratorEmailAddressNavigation { get; set; } = null!;
}
