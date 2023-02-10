namespace VMix.CQRS.Contracts.NavMenuContracts;

public class ConfigNavMenuDto
{
    public int id { get; set; }
    public int? parentNodeID { get; set; }
    public string title { get; set; }
    public string icon { get; set; }
    public string href { get; set; }
    public bool isHeader { get; set; }
    public bool isParent { get; set; }
    public int lineNr { get; set; }
}
