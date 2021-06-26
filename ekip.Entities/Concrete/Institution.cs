using System.Collections.Generic;
using ekip.Core.Entities.Abstract;

namespace ekip.Entities.Concrete
{
    public class Institution : IEntity
    {
        public Institution()
        {
            Streams = new List<Stream>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string ContactInfo { get; set; }
        public int Code { get; set; }
        public List<Stream> Streams { get; set; }
        public virtual List<Staff> Staffs { get; set; }
        public virtual List<Board> Boards { get; set; }
    }
}
