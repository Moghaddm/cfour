namespace CFour.EndPoints.Compare.Create;

public record CreateCompareRequest(
    string GameId,
    string ChosenSystemSpecificationUnique
);