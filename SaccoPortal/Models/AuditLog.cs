﻿namespace SaccoPortal.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public required string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public required string UserId { get; set; }
        public required string Details { get; set; }
    }

}
