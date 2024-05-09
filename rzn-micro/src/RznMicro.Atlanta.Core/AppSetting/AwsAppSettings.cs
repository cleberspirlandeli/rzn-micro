namespace RznMicro.Atlanta.Core.AppSetting;

public class AwsAppSettings
{
    public CredentialsAppSettings Credentials { get; set; }
    public SqsAppSettings SQS { get; set; }
    public S3AppSettings S3 { get; set; }
}
