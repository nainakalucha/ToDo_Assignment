﻿using Adform_ToDo.DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Adform_ToDo.Tests.DALTests
{
    public class ToDoDbContextInitiator : MapperInitiator
    {
        public ToDoDbContext DBContext { get; }
        public ToDoDbContextInitiator()
        {
            DbContextOptionsBuilder<ToDoDbContext> builder = new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(databaseName: "ToDoDb");

            ToDoDbContext _toDoDbContext = new ToDoDbContext(builder.Options);
            DBContext = _toDoDbContext;
        }
    }
}
