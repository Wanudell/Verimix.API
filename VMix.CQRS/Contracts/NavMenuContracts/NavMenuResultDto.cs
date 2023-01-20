namespace VMix.CQRS.Contracts.NavMenuContracts;

public class NavMenuResultDto
{
    public bool? header { get; set; }
    public string? title { get; set; }
    public string? icon { get; set; }
    public string? href { get; set; }
    public List<Child>? child { get; set; }
}

public class Child
{
    public string? title { get; set; }
    public string? href { get; set; }
}