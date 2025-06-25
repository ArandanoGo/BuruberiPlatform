namespace BURUBERI.InventoryService.API.Messaging;

public static class MessageBusConstants
{
    public const string ExchangeName = "review-requests-exchange";
    public const string QueueName = "review-request-queue";
    public const string RoutingKeyGetReviewsByLote = "get-reviews-by-lote";
}