using Blackbird.Applications.Sdk.Common;
using File = Pipedrive.File;

namespace Apps.Pipedrive.Models.Dto;

public class FileDto
{
    [Display("ID")]
    public string Id { get; set; }

    [Display("Name")]
    public string Name { get; set; }

    [Display("File name")]
    public string FileName { get; set; }
    
    [Display("File type")]
    public string FileType { get; set; }

    [Display("Description")]
    public string Description { get; set; }

    [Display("User ID")]
    public string? UserId { get; set; }

    [Display("Deal ID")]
    public string? DealId { get; set; }

    [Display("Person ID")]
    public string? PersonId { get; set; }

    [Display("Organization ID")]
    public string? OrgId { get; set; }

    [Display("Product ID")]
    public string? ProductId { get; set; }

    [Display("Email message ID")]
    public string? EmailMessageId { get; set; }

    [Display("Activity ID")]
    public string? ActivityId { get; set; }

    [Display("Note ID")]
    public string? NoteId { get; set; }

    [Display("Log ID")]
    public string? LogId { get; set; }

    [Display("File size")]
    public long FileSize { get; set; }

    [Display("S3 bucket")]
    public string S3Bucket { get; set; }

    [Display("URL")]
    public string Url { get; set; }
    
    [Display("Add time")]
    public DateTime? AddTime { get; set; }

    public FileDto(File file)
    {
        Id = file.Id.ToString();
        Name = file.Name;
        FileName = file.FileName;
        FileType = file.FileType;
        Description = file.Description;
        UserId = file.UserId.ToString();
        DealId = file.DealId.ToString();
        PersonId = file.PersonId.ToString();
        OrgId = file.OrgId.ToString();
        ProductId = file.ProductId.ToString();
        EmailMessageId = file.EmailMessageId.ToString();
        ActivityId = file.ActivityId.ToString();
        NoteId = file.NoteId.ToString();
        LogId = file.LogId.ToString();
        FileSize = file.FileSize;
        S3Bucket = file.S3Bucket;
        Url = file.Url;
        AddTime = file.AddTime;
    }
}