using Grpc.Net.Client.Web;

namespace RegularScript.Ui.Models;

public class GrpcServiceOptions
{
    public const string ConfigurationPath = "GrpcService";

    public GrpcWebMode Mode { get; set; }
    public string Host { get; set; } = string.Empty;
}