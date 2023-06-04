using System.ComponentModel.DataAnnotations;

public class TicketFormModel{
    [Required]
    public string? Name {get; set;}
    [Required]
    public string? Project {get; set;}
    [Required]
    public string? Type {set; get;}
    [Required]
    public string? Severity {set; get;}
    public string? Description {set; get;}
}