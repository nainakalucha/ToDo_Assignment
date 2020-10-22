using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Adform_Todo.Common.Helpers
{
    /// <summary>
    /// Mapping class used by automapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User mapping  
            CreateMap<UserModel, UserDto>();
            CreateMap<CreateUserModel, CreateUserDto>();
            CreateMap<CreateUserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            //Labels mapping
            CreateMap<LabelEntity, LabelDto>();
            CreateMap<LabelDto, LabelModel>();

            CreateMap<CreateLabelModel, CreateLabelDto>();
            CreateMap<CreateLabelDto, LabelEntity>();

            CreateMap<AssignLabelToListModel, AssignLabelToListDto>();
            CreateMap<AssignLabelToListDto, ToDoListLabelsEntity>();

            CreateMap<AssignLabelToItemModel, AssignLabelToItemDto>();
            CreateMap<AssignLabelToItemDto, ToDoItemLabelsEntity>();

            CreateMap<DeleteLabelModel, DeleteLabelDto>();

            //ToDoList mapping
            CreateMap<ToDoListDto, ToDoListModel>();
            CreateMap<JsonPatchDocument<UpdateToDoListModel>, JsonPatchDocument<UpdateToDoListDto>>();
            CreateMap<Operation<UpdateToDoListModel>, Operation<UpdateToDoListDto>>();
            CreateMap<ToDoListDto, UpdateToDoListDto>();
            CreateMap<TodoListEntity, ToDoListDto>();
            CreateMap<ToDoListLabelsEntity, ToDoListLabelsDto>();

            CreateMap<CreateToDoListModel, CreateToDoListDto>();
            CreateMap<CreateToDoListDto, TodoListEntity>();

            CreateMap<UpdateToDoListModel, UpdateToDoListDto>();
            CreateMap<UpdateToDoListDto, TodoListEntity>().ReverseMap();
            CreateMap<UpdateToDoListDto, ToDoListModel>();

            CreateMap<DeleteToDoListModel, DeleteToDoListDto>();

            //ToDoItem mapping
            CreateMap<ToDoItemDto, ToDoItemModel>();
            CreateMap<TodoItemEntity, ToDoItemDto>();
            CreateMap<ToDoItemLabelsEntity, ToDoItemLabelsDto>();
            CreateMap<JsonPatchDocument<UpdateToDoItemModel>, JsonPatchDocument<UpdateToDoItemDto>>();
            CreateMap<Operation<UpdateToDoItemModel>, Operation<UpdateToDoItemDto>>();
            CreateMap<ToDoItemDto, UpdateToDoItemDto>();

            CreateMap<CreateToDoItemModel, CreateToDoItemDto>();
            CreateMap<CreateToDoItemDto, TodoItemEntity>();

            CreateMap<UpdateToDoItemModel, UpdateToDoItemDto>();
            CreateMap<UpdateToDoItemDto, TodoItemEntity>().ReverseMap();
            CreateMap<UpdateToDoItemDto, ToDoItemModel>();

            CreateMap<DeleteToDoItemModel, DeleteToDoItemDto>();



        }
    }
}
