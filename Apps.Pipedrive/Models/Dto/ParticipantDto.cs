using Blackbird.Applications.Sdk.Common;
using Pipedrive;

namespace Apps.Pipedrive.Models.Dto;

public class ParticipantDto
{
    [Display("Person ID")]
    public string PersonId { get; set; }

    public ParticipantDto(Participant participant)
    {
        PersonId = participant.PersonId.ToString();
    }
}