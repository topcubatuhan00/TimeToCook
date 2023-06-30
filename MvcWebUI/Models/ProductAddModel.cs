namespace MvcWebUI.Models;

public sealed record ProductAddModel(
        string Name,
        string Photo,
        string CreatedDate,
        string Amount,
        string SKTDate
    );
