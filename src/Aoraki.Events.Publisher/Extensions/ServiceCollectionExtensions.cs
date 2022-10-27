using System;
using Aoraki.Events.Contracts;
using Azure.Identity;
using Azure.Messaging.EventGrid;
using Microsoft.Extensions.DependencyInjection;

namespace Aoraki.Events.Publisher.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection
        AddAorakiEventsPublisher(this IServiceCollection services, string domainEndpoint) =>
        services.AddSingleton<IEventPublisher, EventPublisher>()
            .AddSingleton<IBlogEventPublisher, BlogEventPublisher>()
            .AddSingleton(new EventGridPublisherClient(new Uri(domainEndpoint), new DefaultAzureCredential()));
}