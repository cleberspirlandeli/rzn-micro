namespace RznMicro.Atlanta.Core.AppSetting;

public class SqsAppSettings
{
    public QueueAppSettings AddUser { get; set; }
    public QueueAppSettings UpdateUser { get; set; }
    public QueueAppSettings DeleteUser { get; set; }
}
