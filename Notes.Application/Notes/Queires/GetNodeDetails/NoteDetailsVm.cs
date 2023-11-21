using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;
using System;

namespace Notes.Application.Notes.Queires.GetNodeDetails
{
    public class NoteDetailsVm: IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteDetailsVm>();
        }
    }
}
