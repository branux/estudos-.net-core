﻿namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
    }
}
