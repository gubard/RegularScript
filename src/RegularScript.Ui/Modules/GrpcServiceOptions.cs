using Grpc.Net.Client.Web;

namespace RegularScript.Ui.Modules;

public class GrpcServiceOptions
{
    public GrpcWebMode Mode { get; set; }
    public string Url { get; set; }
}