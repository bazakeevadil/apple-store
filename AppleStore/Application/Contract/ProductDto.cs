﻿namespace Application.Contract;

public record ProductDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required Guid CategoryId { get; init; }
}
