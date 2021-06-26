using System;
using System.Collections.Generic;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Board : IEntity
    {
        public Board()
        {
            BoardContexts = new List<BoardContext>();
            Followers = new List<Follower>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
        public List<BoardContext> BoardContexts { get; set; }
        public List<Follower> Followers { get; set; }
    }
}
