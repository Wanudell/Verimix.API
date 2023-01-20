namespace VMix.Data.Entities;

[Table("ConfigNavMenus")]
public class ConfigNavMenu : BaseEntity
{
    public int? parentNodeID { get; set; }
    public string title { get; set; }
    public string icon { get; set; }
    public string href { get; set; }
    public bool isHeader { get; set; }
    public bool isParent { get; set; }
    public int lineNo { get; set; }

}