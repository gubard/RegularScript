using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient.Language;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Services;

public class LanguageService : ILanguageService
{
    private readonly IMapper mapper;

    public LanguageService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async Task<IEnumerable<Language>> GetAllAsync()
    {
        var httpHandler = new HttpClientHandler();

        // This is for development purposes only; do not use in production.
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        var channelOptions = new GrpcChannelOptions { HttpHandler = httpHandler };
        // Create a channel to the gRPC server
        var channel = GrpcChannel.ForAddress("https://localhost:5002", channelOptions);

        // Create a client for the Greeter service
        var client = new LanguageServiceApi.LanguageServiceApiClient(channel);

        // Create a request message
        var request = new GetAllRequest();

        // Call the SayHello method on the server
        var reply = await client.GetAllAsync(request);

        // Shutdown the channel gracefully
        await channel.ShutdownAsync();

        return reply.Languages.Select(x => mapper.Map<Language>(x)).ToArray();
    }
}