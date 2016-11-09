using AutoMapper;
using System.Runtime.CompilerServices;
using TodoApp.Domain.Dtos;
using TodoApp.Domain.Entities;

[assembly: InternalsVisibleTo("TodoApp.Infra.CrossCutting")]
namespace TodoApp.Service
{
    internal abstract class BaseService
    {
        public BaseService()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Todo, TodoDTO>().ReverseMap());
        }
    }
}
